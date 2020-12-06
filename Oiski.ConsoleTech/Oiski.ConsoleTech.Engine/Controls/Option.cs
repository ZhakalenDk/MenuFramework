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
        /// <param name="_attachToEngine">Whether or not to attach this <see cref="SelectableControl"/> direclty to the <see cref="OiskiEngine"/></param>
        public Option(string _text, bool _attachToEngine = true) : base(_text, _attachToEngine)
        {

        }

        /// <summary>
        /// INitialize a new instance of type <see cref="Option"/> where the text and position is set.
        /// </summary>
        /// <param name="_text"></param>
        /// <param name="_positon"></param>
        /// <param name="_attachToEngine"></param>
        public Option(string _text, Vector2 _positon, bool _attachToEngine = true) : this(_text, _attachToEngine)
        {
            Position = _positon;
        }
    }
}
