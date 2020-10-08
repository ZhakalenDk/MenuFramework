using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.ConsoleTech
{
    public class Renderer
    {
        protected int BorderThickness_X = 1;
        protected int BorderThickness_Y = 1;
        public char[,] Grid { get; protected set; } = null;
        public RenderConfiguration Configuration { get; protected set; } = new RenderConfiguration(new Vector2(Console.WindowWidth, Console.WindowHeight), '+', '|', '-');

        public void InitRenderer ()
        {
            if ( Configuration == null )
            {
                throw new Exception("Renderer Configuration can't be null!");
            }

            Console.CursorVisible = false;
            InitGrid(Configuration.Size.x, Configuration.Size.y);
        }

        private void InitGrid (int _x, int _y)
        {
            Grid = new char[_x, _y];
            BuildScreenBorder();
        }

        protected virtual void BuildScreenBorder ()
        {
            if ( Grid == null || Configuration == null )
            {
                throw new Exception("Grid or Configuration can't be null!");
            }

            for ( int y = 0; y < Grid.GetLength(1); y++ )
            {
                for ( int x = 0; x < Grid.GetLength(0); x++ )
                {
                    if ( x == 0 || x == Grid.GetLength(0) - 1 )
                    {
                        if ( y == 0 || y == Grid.GetLength(1) - 1 )
                        {
                            Grid[x, y] = Configuration.GetCornerChar;

                        }
                        else
                        {
                            Grid[x, y] = Configuration.GetVerticalChar;
                        }

                    }
                    else if ( y == 0 || y == Grid.GetLength(1) - 1 )
                    {
                        Grid[x, y] = Configuration.GetHorizontalChar;
                    }
                    else
                    {
                        Grid[x, y] = ' ';
                    }
                }
            }
        }

        public virtual void InsertAt (Vector2 _position, char _symbol)
        {
            _position = new Vector2(_position.x + BorderThickness_X, _position.y + BorderThickness_Y);

            #region Legacy Code
            //if ( _position.x < 1 )
            //{
            //    _position = new Vector2(1, _position.y);
            //}
            //else if ( _position.x > ( Grid.GetLength(0) - ( BORDERTHICKNESS_X + 1 ) ) )
            //{
            //    _position = new Vector2(Grid.GetLength(0) - ( BORDERTHICKNESS_X + 1 ), _position.y);
            //}

            //if ( _position.y < 1 )
            //{
            //    _position = new Vector2(_position.x, 1);
            //}
            //else if ( _position.y > ( Grid.GetLength(1) - ( BORDERTHICKNESS_Y + 1 ) ) )
            //{
            //    _position = new Vector2(_position.x, Grid.GetLength(1) - ( BORDERTHICKNESS_Y + 1 ));
            //}
            #endregion

            if ( _position.x >= 1 && _position.x <= ( Grid.GetLength(0) - ( BorderThickness_X + 1 ) ) && _position.y >= 1 && _position.y <= ( Grid.GetLength(1) - ( BorderThickness_Y + 1 ) ) )
            {
                Grid[_position.x, _position.y] = _symbol;
            }

        }

        public virtual void InsertAt (Vector2 _position, string _toInsert)
        {
            int xAxis = _position.x;
            for ( int i = 0; i < _toInsert.Length; i++ )
            {
                #region Legacy Code
                //if ( xAxis > Grid.GetLength(0) - ( BORDERTHICKNESS_X + 2 ) )
                //{
                //    break;
                //}
                #endregion
                InsertAt(new Vector2(xAxis, _position.y), _toInsert[i]);
                xAxis++;
            }
        }

        public virtual void Render ()
        {
            if ( Grid != null && Grid.Length != 0 )
            {
                for ( int y = 0; y < Grid.GetLength(1); y++ )
                {
                    for ( int x = 0; x < Grid.GetLength(0); x++ )
                    {
                        Console.Write(Grid[x, y]);
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                throw new Exception("Grid is empty or null. Aborting rendering process!");
            }

            Console.SetCursorPosition(0, 0);
        }
    }
}
