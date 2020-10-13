using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.ConsoleTech.Engine.Controls
{
    /// <summary>
    /// Defines a <see cref="Control"/> that can be selected during runtime
    /// </summary>
    public class Option : SelectableControl
    {
        /// <summary>
        /// Initializes a new instance of type <see cref="Option"/> where the text of the <see cref="Control"/> is set to <paramref name="_text"/>
        /// </summary>
        /// <param name="_text"></param>
        public Option(string _text, bool _attachToEngine = true) : base(_text, _attachToEngine)
        {

        }

        public Option(string _text, Vector2 _positon, bool _attachToEngine = true) : this(_text, _attachToEngine)
        {
            Position = _positon;
        }
    }
}
