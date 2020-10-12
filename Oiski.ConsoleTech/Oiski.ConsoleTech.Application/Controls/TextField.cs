using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oiski.ConsoleTech.Engine.Controls
{
    /// <summary>
    /// Represents a <see cref="Control"/> that can be read from and written to during runtime
    /// </summary>
    public class TextField : Option
    {
        /// <summary>
        /// Occures when the <see cref="TextField"/> is selected
        /// </summary>
        protected new readonly Action<SelectableControl> OnSelect;
        /// <summary>
        /// If set to <see langword="true"/>, this will erase any text inside the <see cref="TextField"/> before its write state is initiated 
        /// </summary>
        public bool EraseTextOnSelect { get; set; } = false;
        /// <summary>
        /// If set to <see langword="true"/> this will set the <see cref="EraseTextOnSelect"/> to <see langword="false"/> after the first initiated write state
        /// </summary>
        public bool ResetAfterFirstWrite { get; set; } = true;

        /// <summary>
        /// Initializes a new instance of type <see cref="TextField"/> where the text is set
        /// </summary>
        /// <param name="_text"></param>
        public TextField (string _text) : base(_text)
        {
            OnSelect = BeginWrite;
            base.OnSelect += OnSelect;
        }

        /// <summary>
        /// Initializes a new instance of type <see cref="TextField"/> where the text and position is set
        /// </summary>
        /// <param name="_text"></param>
        /// <param name="_positon"></param>
        public TextField (string _text, Vector2 _positon) : this(_text)
        {
            Position = _positon;
        }

        /// <summary>
        /// Initiates the <see cref="TextField"/>s write state
        /// </summary>
        /// <param name="_me"></param>
        private void BeginWrite (SelectableControl _me)
        {
            if ( OiskiEngine.Input.CanWrite )
            {
                OiskiEngine.Input.SetWriting(false);
                OiskiEngine.Input.SetNavigation(true);
            }
            else
            {
                OiskiEngine.Input.SetNavigation(false);
                OiskiEngine.Input.SetWriting(true);

                if ( !EraseTextOnSelect )
                {
                    _me.Text = OiskiEngine.Input.SetTextInput(_me.Text);
                }

                if ( ResetAfterFirstWrite )
                {
                    EraseTextOnSelect = false;
                    ResetAfterFirstWrite = false;
                }

                ThreadPool.QueueUserWorkItem(WriteToMe);
            }
        }

        /// <summary>
        /// Updates the <see cref="TextField"/>s text value
        /// </summary>
        /// <param name="_state"></param>
        private void WriteToMe (object _state)
        {
            do
            {
                this.Text = OiskiEngine.Input.TextInput;
            } while ( OiskiEngine.Input.CanWrite );
        }
    }
}
