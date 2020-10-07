﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate_Playground.MenuFramework.Controls
{
    public class Label
    {
        private char[,] grid = new char[3, 3];
        private readonly char[] border = { '+', '|', '-' };

        public string Text { get; set; } = string.Empty;

        public Vector2 Size { get; protected set; }

        public Vector2 Position { get; set; }

        public bool EnsureSize { get; set; } = true;

        private void CorrectSize ()
        {
            if ( Size.x < Text.Length )
            {
                Size = new Vector2(Text.Length + 1, Size.y);
            }

            if ( Size.y < 3 )
            {
                Size = new Vector2(Size.x, 3);
            }

            grid = new char[Size.x, Size.y];
        }

        public char[,] Draw ()
        {
            if ( EnsureSize )
            {
                CorrectSize();
            }

            int textIndex = 0;
            for ( int y = 0; y < grid.GetLength(1); y++ )
            {
                for ( int x = 0; x < grid.GetLength(0); x++ )
                {
                    if ( x == 0 || x == grid.GetLength(0) - 1 )
                    {
                        if ( y == 0 || y == grid.GetLength(1) - 1 )
                        {
                            grid[x, y] = border[( int ) BorderArea.Corner];

                        }
                        else
                        {
                            grid[x, y] = border[( int ) BorderArea.Vertical];
                        }

                    }
                    else if ( y == 0 || y == grid.GetLength(1) - 1 )
                    {
                        grid[x, y] = border[( int ) BorderArea.Horizontal];
                    }
                    else
                    {
                        grid[x, y] = Text[textIndex];
                        textIndex++;
                    }
                }
            }

            return grid;
        }

        public Label (string _text) : base()
        {
            Text = _text;
            Size = new Vector2(Text.Length + 2, 3);
            Position = new Vector2(0, 0);
        }
    }
}
