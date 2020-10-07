using Delegate_Playground.MenuFramework.Controls;

namespace Delegate_Playground.MenuFramework
{
    public class RenderConfiguration
    {
        public Vector2 Size { get; set; }

        public char GetCornerChar
        {
            get
            {
                return boundaryChars[( int ) Boundary.MapCornerChar];
            }
        }

        public char GetVerticalChar
        {
            get
            {
                return boundaryChars[( int ) Boundary.MapVerticalChar];
            }
        }

        public char GetHorizontalChar
        {
            get
            {
                return boundaryChars[( int ) Boundary.MapHorizontalChar];
            }
        }

        private readonly char[] boundaryChars;

        public void ChangeBorderArea (BorderArea _area, char _style)
        {
            boundaryChars[( int ) _area] = _style;
        }

        public RenderConfiguration (Vector2 _size, char _mapCornerChar, char _mapVerticalChar, char _mapHorizontalChar)
        {
            Size = _size;

            boundaryChars = new char[3];
            boundaryChars[( int ) Boundary.MapCornerChar] = _mapCornerChar;
            boundaryChars[( int ) Boundary.MapVerticalChar] = _mapVerticalChar;
            boundaryChars[( int ) Boundary.MapHorizontalChar] = _mapHorizontalChar;
        }

        protected enum Boundary
        {
            MapCornerChar,
            MapVerticalChar,
            MapHorizontalChar
        }
    }
}