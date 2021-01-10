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
        /// The color applied to the highlighted <see cref="ListBoxItem{ValueType}"/> in the <see cref="ColorableListBox{T}"/>
        /// </summary>
        public RenderColor HighlightColor { get; set; }
        /// <summary>
        /// The 2-dimensional <see cref="RenderColor"/> grid mapping the colors for the <see cref="IColorableControl"/>
        /// </summary>
        public RenderColor[,] ColorGrid { get; private set; }
        /// <summary>
        /// The offset from the left border
        /// </summary>
        public int LeftMargin { get; set; } = 3;
        /// <summary>
        /// The offset from the right border
        /// </summary>
        public int RightMargin { get; set; } = 3;
        /// <summary>
        /// The offset from the top border
        /// </summary>
        public int TopMargin { get; set; } = 1;
        /// <summary>
        /// The offset from the bottom border
        /// </summary>
        public int BottomMargin { get; set; } = 1;

        /// <summary>
        /// The collection of <see cref="ListBoxItem{ValueType}"/>
        /// </summary>
        public ListBoxItemCollection<T> Items { get; } = new ListBoxItemCollection<T>();
        /// <summary>
        /// The maximum amount of <see cref="ListBoxItem{ValueType}"/> that can be displayed at any given time in the <see cref="ColorableListBox{T}"/>.
        /// This defines the inner height of the content section.
        /// </summary>
        public int MaxPrPage
        {
            get
            {
                return maxPrPage;
            }
            set
            {
                displayedItems = new ListBoxItem<T>[value];
                maxPrPage = value;
            }
        }
        private int maxPrPage;

        /// <summary>
        /// Whether or not the items in the list can be navigated and selected
        /// </summary>
        public bool SelectableItems { get; set; }
        /// <summary>
        /// Returns the currently selected <see cref="ListBoxItem{ValueType}"/> in the list. If <see cref="SelectableItems"/> is not <see langword="true"/> this will return <see langword="null"/>
        /// </summary>
        public ListBoxItem<T> GetSelectedItem
        {
            get
            {
                return displayedItems[SelectedItemIndex];
            }
        }
        /// <summary>
        /// The index of the currently highlighted <see cref="ListBoxItem{ValueType}"/>
        /// </summary>
        public int SelectedItemIndex
        {
            get
            {
                return selectedItemIndex;
            }
            protected set
            {
                if ( value < 0 )
                {
                    startIndex--;

                    if ( startIndex < 0 )
                    {
                        startIndex = 0;
                    }
                }
                else if ( value > maxPrPage - 1 )
                {
                    startIndex++;

                    if ( startIndex > maxPrPage - 1 )
                    {
                        startIndex = maxPrPage - 1;
                    }
                }

                selectedItemIndex = value;
            }
        }
        private int selectedItemIndex = 0;
        /// <summary>
        /// Defines the index at which the iteration for populating the <see cref="ColorableListBox{T}"/> should begin
        /// </summary>
        private int startIndex = 0;
        private ListBoxItem<T>[] displayedItems;

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
                    if ( ( x == 0 || x == grid.GetLength(0) - 1 ) || ( y == 0 || y == 2 || y == grid.GetLength(1) - 1 ) )   //   Building border
                    {
                        #region Border Building
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
                        #endregion

                        #region Header Underline
                        if ( y == 2 && ( x != 0 && x != grid.GetLength(0) - 1 ) )   //  Building Header underline
                        {
                            grid[x, y] = border[( int ) BorderArea.Horizontal];
                        }
                        #endregion

                        ColorGrid[x, y] = BorderColor;
                    }
                    else if ( ( x >= ( Size.x / 2f - Text.Length / 2f ) && y == 1 ) && headerIndex < Text.Length )  //  Building header content
                    {
                        grid[x, y] = Text[headerIndex];
                        headerIndex++;
                        ColorGrid[x, y] = TextColor;
                    }
                    else if ( ( x > LeftMargin && x < grid.GetLength(0) - ( 1 + RightMargin ) ) && ( y > ( 2 + TopMargin ) && y < grid.GetLength(1) - ( 1 + BottomMargin ) ) )  //  Building list content
                    {
                        if ( itemIndex <= MaxPrPage && itemIndex < Items.Count && itemTextIndex < Items[itemIndex].Text.Length )    //  adding each letter in the item text to the grid
                        {
                            if ( displayedItems[itemIndex] == null )    //   Ensuring the display array is always populated
                            {
                                displayedItems[itemIndex] = Items[itemIndex];
                            }

                            grid[x, y] = displayedItems[itemIndex][itemTextIndex];

                            #region Color Mapping
                            if ( SelectableItems && IsSelected && ( itemIndex == SelectedItemIndex ) )
                            {
                                ColorGrid[x, y] = HighlightColor;
                            }
                            else
                            {
                                ColorGrid[x, y] = TextColor;
                            }
                            #endregion

                            itemTextIndex++;
                        }
                    }
                }

                if ( itemIndex < Items.Count && itemTextIndex >= Items[itemIndex].Text.Length ) //  Targeting the next item in the collection
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
        /// Updates the list based on the <see cref="startIndex"/> and <see cref="SelectedItemIndex"/>
        /// </summary>
        private void UpdateList ()
        {
            if ( selectedItemIndex > MaxPrPage - 1 || selectedItemIndex < 0 )
            {
                for ( int i = 0, index = startIndex; i < displayedItems.Length; i++, index++ )
                {
                    displayedItems[i] = Items[index];
                }
            }

            #region Clamp Index between 0 and maxPrPage - 1
            if ( selectedItemIndex >= maxPrPage )
            {
                selectedItemIndex = maxPrPage - 1;
            }
            else if ( selectedItemIndex < 0 )
            {
                selectedItemIndex = 0;
            }
            #endregion

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


            if ( _innerWidth < _header.Length ) //  To ensure that the header always fits inside the listbox
            {
                _innerWidth = _header.Length;
            }

            SetSize(MaxPrPage, _innerWidth);

            OnSelect += Select;
            OnUpdate += Update;
        }

        /// <summary>
        /// The event that handles the navigation of the items in the listbox when <see cref="SelectableItems"/> is <see langword="true"/>.
        /// </summary>
        /// <param name="_control"></param>
        protected virtual void Update (Control _control)
        {
            if ( IsSelected && SelectableItems )
            {
                if ( OiskiEngine.Input.InputInfo.Key == ConsoleKey.UpArrow )
                {
                    SelectedItemIndex--;
                    OiskiEngine.Input.ResetInput();
                    UpdateList();
                }
                if ( OiskiEngine.Input.InputInfo.Key == ConsoleKey.DownArrow )
                {
                    SelectedItemIndex++;
                    OiskiEngine.Input.ResetInput();
                    UpdateList();
                }
            }
        }

        /// <summary>
        /// The behavior that is triggered when the <see cref="ColorableListBox{T}"/> is selected
        /// </summary>
        /// <param name="_control"></param>
        protected virtual void Select (SelectableControl _control)
        {
            if ( OiskiEngine.Input.NavigationEnabled )
            {
                OiskiEngine.Input.SetNavigation(false);
            }
            else
            {
                OiskiEngine.Input.SetNavigation(true);
                IsSelected = false;
            }
        }
    }
}