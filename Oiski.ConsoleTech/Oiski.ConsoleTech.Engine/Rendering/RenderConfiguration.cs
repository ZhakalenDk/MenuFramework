using Oiski.ConsoleTech.Engine.Controls;

namespace Oiski.ConsoleTech.Engine.Rendering
{
    /// <summary>
    /// Defines a storage of settings that can be <strong>directly</strong> applied to the <see cref="Renderer"/> <see langword="class"/>
    /// </summary>
    public class RenderConfiguration
    {
        /// <summary>
        /// This is the <strong>horizontal</strong> and <strong>vertical</strong> size of the screenspace that the <see cref="Renderer"/> will render
        /// </summary>
        public Vector2 Size { get; set; }

        /// <summary>
        /// The <see langword="char"/> the <see cref="Renderer"/> will use as <strong>corner</strong> for the screen border
        /// </summary>
        public char GetCornerChar
        {
            get
            {
                return boundaryChars[( int ) Border.CornerChar];
            }
        }
        /// <summary>
        /// The <see langword="char"/> the <see cref="Renderer"/> will use as <strong>vertical</strong> screen border
        /// </summary>
        public char GetVerticalChar
        {
            get
            {
                return boundaryChars[( int ) Border.VerticalChar];
            }
        }

        /// <summary>
        /// The <see langword="char"/> the <see cref="Renderer"/> will use as <strong>horizontal</strong> screen border
        /// </summary>
        public char GetHorizontalChar
        {
            get
            {
                return boundaryChars[( int ) Border.HorizontalChar];
            }
        }

        private readonly char[] boundaryChars;

        /// <summary>
        /// Change the style of the border defined by <paramref name="_area"/>
        /// </summary>
        /// <param name="_area"></param>
        /// <param name="_style"></param>
        public void ChangeBorderStyle(BorderArea _area, char _style)
        {
            boundaryChars[( int ) _area] = _style;
        }

        /// <summary>
        /// Initializes a new instance of type <see cref="RenderConfiguration"/> where the size of the <strong>screenspace</strong> is defined by <paramref name="_size"/>.
        /// <br/>
        /// The border of the <strong>screenspace</strong> is rendered based on <paramref name="_borderCornerChar"/>, <paramref name="_borderVerticalChar"/>, <paramref name="_borderHorizontalChar"/>.
        /// </summary>
        /// <param name="_size"></param>
        /// <param name="_borderCornerChar"></param>
        /// <param name="_borderVerticalChar"></param>
        /// <param name="_borderHorizontalChar"></param>
        public RenderConfiguration(Vector2 _size, char _borderCornerChar, char _borderVerticalChar, char _borderHorizontalChar)
        {
            Size = _size;

            boundaryChars = new char[3];
            boundaryChars[( int ) Border.CornerChar] = _borderCornerChar;
            boundaryChars[( int ) Border.VerticalChar] = _borderVerticalChar;
            boundaryChars[( int ) Border.HorizontalChar] = _borderHorizontalChar;
        }

        /// <summary>
        /// Maps the Border <see langword="chars"/> in the <see cref="boundaryChars"/> <see langword="array"/>
        /// </summary>
        protected enum Border
        {
            /// <summary>
            /// The character used to draw the corners for the border
            /// </summary>
            CornerChar,
            /// <summary>
            /// The character used to draw the vertical border
            /// </summary>
            VerticalChar,
            /// <summary>
            /// The character used to draw the horizontal border
            /// </summary>
            HorizontalChar
        }
    }
}