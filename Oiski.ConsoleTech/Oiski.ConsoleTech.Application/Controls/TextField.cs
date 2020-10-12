using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oiski.ConsoleTech.Engine.Controls
{
    public class TextField : Option
    {
        protected new readonly Action<SelectableControl> OnSelect;
        public TextField (string _text) : base(_text)
        {
            OnSelect = BeginWrite;
            base.OnSelect += OnSelect;
        }

        public TextField (string _text, Vector2 _positon) : this(_text)
        {
            Position = _positon;
        }

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
                _me.Text = OiskiEngine.Input.SetTextInput(_me.Text);

                ThreadPool.QueueUserWorkItem(WriteToMe);
            }
        }

        private void WriteToMe (object _state)
        {
            do
            {
                this.Text = OiskiEngine.Input.TextInput;
            } while ( OiskiEngine.Input.CanWrite );
        }
    }
}
