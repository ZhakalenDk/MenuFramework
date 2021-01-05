using Oiski.ConsoleTech.Engine.Color.Controls;
using Oiski.ConsoleTech.Engine.Color.Rendering;
using Oiski.ConsoleTech.Engine.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.ConsoleTech.Engine.Color.Controls
{
    /// <summary>
    /// Defines a box containing a <see cref="ListBoxItemCollection{T}"/>
    /// </summary>
    /// <typeparam name="T">The type of the value stored by <see cref="ListBoxItem{ValueType}"/> in the <see cref="ListBoxItemCollection{T}"/></typeparam>
    public class ColorableListBox<T> : SelectableControl, IColorableControl
    {
        /// <summary>
        /// The color of the text inside the <see cref="ColorableListBox{T}"/>
        /// </summary>
        public RenderColor TextColor { get; set; }
        /// <summary>
        /// The color of the border for the <see cref="ColorableListBox{T}"/>
        /// </summary>
        public RenderColor BorderColor { get; set; }
        /// <summary>
        /// The 2-dimensional <see cref="RenderColor"/> grid mapping the colors for the <see cref="IColorableControl"/>
        /// </summary>
        public RenderColor[,] ColorGrid { get; private set; }

        /// <summary>
        /// The collection of <see cref="ListBoxItem{ValueType}"/>
        /// </summary>
        public ListBoxItemCollection<T> Items { get; } = new ListBoxItemCollection<T>();
        /// <summary>
        /// The maximum amount of <see cref="ListBoxItem{ValueType}"/> that can be displayed at any given time in the <see cref="ColorableListBox{T}"/>.
        /// This defines the inner height of the content section.
        /// </summary>
        public int MaxPrPage { get; set; }
        /// <summary>
        /// The offset from the border for each item on the left hand
        /// </summary>
        public int LeftMargin { get; set; } = 3;
        public int RightMargin { get; set; } = 3;
        public int TopMargin { get; set; } = 1;
        public int BottomMargin { get; set; } = 1;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        protected override char[,] Build ()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            grid = new char[Size.x, Size.y];
            ColorGrid = new RenderColor[Size.x, Size.y];

            int headerIndex = 0;
            int itemIndex = 0;
            int itemTextIndex = 0;
            for ( int y = 0; y < grid.GetLength(1); y++ )
            {
                for ( int x = 0; x < grid.GetLength(0); x++ )
                {
                    if ( ( x == 0 || x == grid.GetLength(0) - 1 ) || ( y == 0 || y == 2 || y == grid.GetLength(1) - 1 ) )
                    {
                        if ( ( y == 0 || y == grid.GetLength(1) - 1 ) && ( x > 0 && x < grid.GetLength(0) - 1 ) )
                        {
                            grid[x, y] = border[( int ) BorderArea.Horizontal];
                        }
                        else if ( ( y == 0 || y == grid.GetLength(1) - 1 ) || y == 2 )
                        {
                            grid[x, y] = border[( int ) BorderArea.Corner];
                        }
                        else
                        {
                            grid[x, y] = border[( int ) BorderArea.Vertical];
                        }
                        if ( y == 2 && ( x != 0 && x != grid.GetLength(0) - 1 ) )
                        {
                            grid[x, y] = border[( int ) BorderArea.Horizontal];
                        }

                        ColorGrid[x, y] = BorderColor;
                    }
                    else if ( ( x >= ( Size.x / 2f - Text.Length / 2f ) && y == 1 ) && headerIndex < Text.Length )
                    {
                        grid[x, y] = Text[headerIndex];
                        headerIndex++;
                        ColorGrid[x, y] = TextColor;
                    }
                    else if ( ( x > LeftMargin && x < grid.GetLength(0) - ( 1 + RightMargin ) ) && ( y > ( 2 + TopMargin ) && y < grid.GetLength(1) - ( 1 + BottomMargin ) ) )
                    {
                        if ( itemIndex <= MaxPrPage && itemIndex < Items.Count && itemTextIndex < Items[itemIndex].Text.Length )
                        {
                            grid[x, y] = Items[itemIndex][itemTextIndex];
                            ColorGrid[x, y] = TextColor;

                            itemTextIndex++;
                        }
                    }
                }

                if ( itemIndex < Items.Count && itemTextIndex >= Items[itemIndex].Text.Length )
                {
                    itemTextIndex = 0;
                    itemIndex++;
                }
            }

            return grid;
        }

        /// <summary>
        /// Instantiates the <see cref="Vector2"/> size component for this <see cref="Control"/>
        /// </summary>
        /// <param name="_rows">The amount of rows inside the <see cref="ColorableListBox{T}"/></param>
        /// <param name="_innerWidth">The inner width of the <see cref="ColorableListBox{T}"/></param>
        private void SetSize (int _rows, int _innerWidth)
        {
            Size = new Vector2(_innerWidth + 2 + LeftMargin + RightMargin, _rows + 4 + TopMargin + BottomMargin);  //    +2 because the left and right borders take up 2 columns. +4 because of the top and bottom borders as well as the header and headerline, which in total takes up 4 rows
        }

        /// <summary>
        /// Creates a new instance of type <see cref="ColorableListBox{T}"/> where the header text and colors are set. Additionally the inner width and max displayable item count is also set
        /// </summary>
        /// <param name="_header"></param>
        /// <param name="_maxPrPage">The maximum amount of items that can be displayed at once</param>
        /// <param name="_innerWidth">The width of the <see cref="ColorableListBox{T}"/> - 2</param>
        /// <param name="_textColor">The color of the header and items displayed in the <see cref="ColorableListBox{T}"/></param>
        /// <param name="_borderColor">The color of the <see cref="Control"/>s border</param>
        /// <param name="_attachToEngine">Whether or not to attach this <see cref="Control"/> directly to the engine</param>
        public ColorableListBox (string _header, int _maxPrPage, int _innerWidth, RenderColor _textColor, RenderColor _borderColor, bool _attachToEngine = true) : base(_header, _attachToEngine)
        {
            Text = _header;
            TextColor = _textColor;
            BorderColor = _borderColor;

            MaxPrPage = _maxPrPage;

            if ( _innerWidth < _header.Length )
            {
                _innerWidth = _header.Length;
            }

            SetSize(MaxPrPage, _innerWidth);
        }
    }
}