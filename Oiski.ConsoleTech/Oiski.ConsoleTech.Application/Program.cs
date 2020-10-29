using Oiski.ConsoleTech.Engine;
using Oiski.ConsoleTech.Engine.Color.Controls;
using Oiski.ConsoleTech.Engine.Color.Rendering;
using Oiski.ConsoleTech.Engine.Controls;
using Oiski.ConsoleTech.Engine.Rendering;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Threading;

namespace Oiski.ConsoleTech
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Menu Framework Test";
            //Console.SetWindowSize(65, 30);
            //Console.SetBufferSize(65, 31);

            #region V1
            ///*
            //    +-----+
            //    |     |
            //    |     |
            //    +-----+


            // */

            //string choice = string.Empty;

            //const int MINX = 3;
            //const int MINY = 3;

            //do
            //{
            //    Console.Clear();

            //    int xAxis = 0;
            //    int yAxis = 0;

            //    do
            //    {
            //        Console.ResetColor();
            //        if ( xAxis < MINX )
            //        {
            //            Console.Write("X Axis: ");
            //            Console.ForegroundColor = ConsoleColor.Blue;
            //            if ( !int.TryParse(Console.ReadLine(), out xAxis) || xAxis < MINX )
            //            {
            //                Console.ForegroundColor = ConsoleColor.Red;
            //                Console.WriteLine("X must be an integer value and be higher or equal to 4");
            //                continue;
            //            }
            //        }

            //        Console.ResetColor();

            //        if ( yAxis < MINY )
            //        {
            //            Console.Write("Y Axis: ");
            //            Console.ForegroundColor = ConsoleColor.Blue;
            //            if ( !int.TryParse(Console.ReadLine(), out yAxis) || yAxis < MINY )
            //            {
            //                Console.ForegroundColor = ConsoleColor.Red;
            //                Console.WriteLine("Y must be an integer value and be higher or equal to 3");
            //                continue;
            //            }
            //        }

            //    } while ( xAxis < MINX || yAxis < MINY );


            //    Console.Clear();
            //    Console.ResetColor();

            //    char[,] grid = new char[xAxis, yAxis];


            //    Console.WriteLine($"Size: X({xAxis}) Y({yAxis})");
            //    for ( int y = 0; y < grid.GetLength(1); y++ )
            //    {
            //        for ( int x = 0; x < grid.GetLength(0); x++ )
            //        {
            //            if ( x == 0 || x == grid.GetLength(0) - 1 )
            //            {
            //                if ( y == 0 || y == grid.GetLength(1) - 1 )
            //                {
            //                    grid[x, y] = '+';
            //                    Console.Write(grid[x, y]);

            //                }
            //                else
            //                {
            //                    grid[x, y] = '|';
            //                    Console.Write(grid[x, y]);
            //                }

            //            }
            //            else if ( y == 0 || y == grid.GetLength(1) - 1 )
            //            {
            //                grid[x, y] = '-';
            //                Console.Write(grid[x, y]);
            //            }
            //            else
            //            {
            //                grid[x, y] = ' ';
            //                Console.Write(grid[x, y]);
            //            }

            //        }

            //        Console.Write(Environment.NewLine);
            //    }

            //    Console.Write("Try again?: ");
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //    choice = Console.ReadLine();
            //} while ( choice.ToLower() == "y" || choice.ToLower() == "yes" );
            #endregion

            #region V2
            //WorldConfiguration conf = new WorldConfiguration(new Vector2(11, 7), '+', '|', '-');
            //GameWorld2D world = new GameWorld2D(conf);

            //world.Draw();
            #endregion

            #region V3
            //OiskiEngine.Run();
            #endregion

            #region V4 - Menu Framework
            //Renderer rend = new Renderer();

            //string[] pos = { "0", "0" };
            //do
            //{
            //    rend.InitRenderer();
            //    rend.Draw();
            //    rend.InsertAt(new Vector2(2, 2), '*');
            //    rend.InsertAt(new Vector2(3, 2), '*');
            //    rend.InsertAt(new Vector2(4, 2), '*');
            //    rend.InsertAt(new Vector2(5, 2), '*');
            //    rend.Refresh();
            //    rend.InsertAt(new Vector2(int.Parse(pos[0]), int.Parse(pos[1])), "Hello");
            //    rend.Refresh();
            //    pos = Console.ReadLine().Split(",");

            //} while ( true );

            #endregion

            #region V5 - Label Test
            //Label label = new Label("Hej, Jens. Du er da en lille banantrold!");
            //char[,] d = label.Build();
            //for ( int y = 0; y < label.Size.y; y++ )
            //{
            //    for ( int x = 0; x < label.Size.x; x++ )
            //    {
            //        Console.Write(d[x, y]);
            //    }

            //    Console.WriteLine();
            //}

            //Console.Read();
            #endregion

            #region V6 - Label Insert Test
            //Control label = new Label("Hello, World!");
            //Renderer rend = new Renderer();

            //string[] pos = { "0", "0" };
            //do
            //{
            //    label.Position = new Vector2(int.Parse(pos[0]), int.Parse(pos[1]));
            //    rend.InitRenderer();
            //    int positionX = label.Position.x;
            //    int positionY = label.Position.y;
            //    for ( int y = 0; y < label.Size.y; y++ )
            //    {
            //        for ( int x = 0; x < label.Size.x; x++ )
            //        {
            //            rend.InsertAt(new Vector2(positionX++, positionY), label.Build()[x, y]);
            //        }
            //        positionX = label.Position.x;
            //        positionY++;
            //    }

            //    rend.Draw();
            //    pos = Console.ReadLine().Split(",");
            //    rend.Refresh();
            //} while ( true );
            #endregion

            #region V7 - Draw Multiple Controls Test
            /////MenuEngine engine = new MenuEngine();
            //Label label = new Label("Hello, World");
            //MenuEngine.AddControl(label);
            //Label label2 = new Label("Hello, Second World!", new Vector2(0, 3));
            //MenuEngine.AddControl(label2);

            //Thread newThread = new Thread(MenuEngine.Run);
            //newThread.IsBackground = true;
            //newThread.Name = "Renderer";
            //newThread.Start();

            //System.Timers.Timer timer = new System.Timers.Timer
            //{
            //    Enabled = true,
            //    Interval = 2000
            //};
            //timer.Elapsed += (o, e) => { label2.Text = $"{new Random().Next(0, 20)}"; Label label3 = new Label("I'm a Third!", new Vector2(15, 5)); MenuEngine.AddControl(label3); };

            //timer.Start();

            //var sw = Stopwatch.StartNew();
            //Label threadInfo = new Label($">Thread Name: {Thread.CurrentThread.Name}<|>Time Since Start: {sw.ElapsedMilliseconds / 1000} Seconds<", new Vector2(30, 3));
            //MenuEngine.AddControl(threadInfo);
            //long miliSec = sw.ElapsedMilliseconds;
            //Thread.CurrentThread.Name = "Input";
            //do
            //{
            //    threadInfo.Text = $">Thread Name: {Thread.CurrentThread.Name}<|>Time Since Last Input: {miliSec / 1000} Seconds<";

            //    ConsoleKeyInfo key = Console.ReadKey();
            //    if ( key.Key == ConsoleKey.Backspace )
            //    {
            //        if ( label.Text.Length > 0 )
            //        {
            //            label.Text = label.Text[0..^2];
            //        }
            //    }
            //    else
            //    {
            //        label.Text += key.KeyChar;
            //    }


            //    miliSec = sw.ElapsedMilliseconds;
            //    sw.Restart();

            //} while ( true );
            #endregion

            #region V8 - Automaticaly Adding Controls on Initialization
            //Label label = new Label("I got automatically added!");
            //Label label2 = new Label("I got automatically added and placed", new Vector2(0, 3));

            //MenuEngine.Run();
            #endregion

            #region V8 - Label Border Control
            //Label label = new Label("Hello, World!");
            //MenuEngine.Run();
            //label.SetBorder(BorderArea.Corner, true);
            //label.SetBorder(BorderArea.Horizontal, false);
            //label.SetBorder(BorderArea.Vertical, true);
            #endregion

            #region V9 - Finding Controls
            //Label label = new Label("Hello, World");
            //label.BorderStyle(BorderArea.Horizontal, '~');
            //label.BorderStyle(BorderArea.Corner, '-');
            //label.SetBorder(BorderArea.Vertical, false);

            //MenuEngine.Run();

            //( ( Label ) MenuEngine.FindControl(0) ).Text = "Hello";
            #endregion

            #region V10 - Input Controller
            //MenuEngine.Run();
            //OptionControl option = new OptionControl("Hello, World!")
            //{
            //    SelectedIndex = new Vector2(0, 1)
            //};

            //OptionControl option2 = new OptionControl("Hello, Second world!", new Vector2(0, 3))
            //{
            //    SelectedIndex = new Vector2(0, 2)
            //};

            //option.OnSelect += OnEnter;

            //do
            //{
            //    option.Position = MenuEngine.Input.GetSelectedIndex;

            //    if ( MenuEngine.Input.CanWrite )
            //    {
            //        option.Text = MenuEngine.Input.TextInput;
            //    }

            //} while ( true );
            #endregion

            #region V11 - Text Control
            //OiskiEngine.Run();
            //TextField field = new TextField("Hello, World");
            #endregion

            #region V12 - Z-Index
            //OiskiEngine.Run();
            //TextField field = new TextField("Hello, World!");
            //field.SetZIndex(-101);

            //do
            //{
            //    field.Position = OiskiEngine.Input.GetSelectedIndex;
            //} while ( true );
            #endregion

            #region V13 - Small Menu Test
            //OiskiEngine.Run();
            //OiskiEngine.Input.AtTarget = AtTarget;
            //OiskiEngine.Input.SetNavigation("Horizontal", false);
            //Label header = new Label("Welcome To Oiski's Database Tool");
            //header.Position = new Vector2(Console.WindowWidth / 2 - ( header.Text.Length - 4 ), 0);

            //InitiateMain(null);
            #endregion

            #region V14 - Menu Control
            //OiskiEngine.Run();
            //OiskiEngine.Input.SetNavigation("Horizontal", false);
            //Menu mainMenu = new Menu();
            //Menu createMenu = new Menu();

            //#region Main Menu
            //Label header = new Label("Welcome To Oiski's Database Tool", false);
            //header.Position = new Vector2(Console.WindowWidth / 2 - ( header.Text.Length - 4 ), 0);
            //mainMenu.Controls.AddControl(header);

            //Option createDB_button = new Option("Create Database", new Vector2(5, 3), false)
            //{
            //    SelectedIndex = new Vector2(0, 0)
            //};

            //createDB_button.BorderStyle(BorderArea.Horizontal, '~');

            //createDB_button.OnSelect += (s) => { mainMenu.Show(false); createMenu.Show(true); OiskiEngine.Input.ResetSlection(); };
            //mainMenu.Controls.AddControl(createDB_button);

            //mainMenu.Show(true);
            //#endregion

            //#region Create DB Menu
            //Label header2 = new Label("Create Database", false)
            //{
            //    Position = new Vector2(Console.WindowWidth / 2 - ( header.Text.Length - 4 ), 0)
            //};
            //createMenu.Controls.AddControl(header2);

            //Label name_label = new Label("Database Name", new Vector2(5, 3), false);
            //TextField databaseName = new TextField("Enter Name here", new Vector2(19, 3), false)
            //{
            //    EraseTextOnSelect = true,
            //    ResetAfterFirstWrite = true,
            //    SelectedIndex = new Vector2(0, 0)
            //};

            //createMenu.Controls.AddControl(name_label);
            //databaseName.BorderStyle(BorderArea.Horizontal, '~');
            //createMenu.Controls.AddControl(databaseName);

            //Label path_label = new Label("Database Path", new Vector2(5, 6), false);
            //TextField databasePath = new TextField("Enter Path here", new Vector2(19, 6), false)
            //{
            //    EraseTextOnSelect = true,
            //    ResetAfterFirstWrite = true,
            //    SelectedIndex = new Vector2(0, 1)
            //};

            //createMenu.Controls.AddControl(databasePath);
            //createMenu.Controls.AddControl(path_label);

            //Option back = new Option("Back", new Vector2(5, 9), false)
            //{
            //    SelectedIndex = new Vector2(0, 2)
            //};

            //back.OnSelect += (s) => { s.BorderStyle(BorderArea.Horizontal, '-'); mainMenu.Show(true); createMenu.Show(false); OiskiEngine.Input.ResetSlection(); };
            //createMenu.Controls.AddControl(back);
            //#endregion
            #endregion

            #region V15 - Library Build
            //OiskiEngine.Run();
            //Menu menu = new Menu();

            //menu.Controls.AddControl(new TextField("I have text", false) { EraseTextOnSelect = true, ResetAfterFirstWrite = true });
            //menu.Show(true);
            #endregion

            #region V16 - Configuration Fix
            //OiskiEngine.Configuration.ChangeBorderStyle(BorderArea.Horizontal, '-');
            //OiskiEngine.Configuration.ChangeBorderStyle(BorderArea.Vertical, '|');
            //OiskiEngine.Configuration.ChangeBorderStyle(BorderArea.Corner, '¤');
            //OiskiEngine.Run();
            #endregion

            #region V17 - Color Rendering
            //Console.SetWindowSize(50, 10);
            var ran = new Random();
            ColorRenderer renderer = new ColorRenderer()
            {
                DefaultColor = new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White))
            };

            //renderer.InitRenderer();

            ColorableLabel label = new ColorableLabel("Hello, World!", new RenderColor(ConsoleColor.Cyan, ConsoleColor.Black), new RenderColor(ConsoleColor.Blue, ConsoleColor.Black));
            ColorableTextField textfield = new ColorableTextField("Hello, World", new RenderColor(ConsoleColor.Cyan, ConsoleColor.Black), new RenderColor(ConsoleColor.Blue, ConsoleColor.Black), new Vector2(ran.Next(0, OiskiEngine.Configuration.Size.x), ran.Next(0, OiskiEngine.Configuration.Size.y)))
            {
                SelectedIndex = new Vector2(0, 0)
            };



            //ColorableOption option = new ColorableOption("I am Colored", new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new Vector2(ran.Next(0, OiskiEngine.Configuration.Size.x), ran.Next(0, OiskiEngine.Configuration.Size.y)));
            //ColorableOption option1 = new ColorableOption("I am Colored", new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new Vector2(ran.Next(0, OiskiEngine.Configuration.Size.x), ran.Next(0, OiskiEngine.Configuration.Size.y)));
            //ColorableOption option2 = new ColorableOption("I am Colored", new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new Vector2(ran.Next(0, OiskiEngine.Configuration.Size.x), ran.Next(0, OiskiEngine.Configuration.Size.y)));
            //ColorableOption option3 = new ColorableOption("I am Colored", new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new Vector2(ran.Next(0, OiskiEngine.Configuration.Size.x), ran.Next(0, OiskiEngine.Configuration.Size.y)));
            //ColorableOption option4 = new ColorableOption("I am Colored", new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new Vector2(ran.Next(0, OiskiEngine.Configuration.Size.x), ran.Next(0, OiskiEngine.Configuration.Size.y)));
            //ColorableOption option5 = new ColorableOption("I am Colored", new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new Vector2(ran.Next(0, OiskiEngine.Configuration.Size.x), ran.Next(0, OiskiEngine.Configuration.Size.y)));
            //ColorableOption option6 = new ColorableOption("I am Colored", new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new Vector2(ran.Next(0, OiskiEngine.Configuration.Size.x), ran.Next(0, OiskiEngine.Configuration.Size.y)));
            //ColorableOption option7 = new ColorableOption("I am Colored", new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new Vector2(ran.Next(0, OiskiEngine.Configuration.Size.x), ran.Next(0, OiskiEngine.Configuration.Size.y)));
            //ColorableOption option8 = new ColorableOption("I am Colored", new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new Vector2(ran.Next(0, OiskiEngine.Configuration.Size.x), ran.Next(0, OiskiEngine.Configuration.Size.y)));
            //ColorableOption option9 = new ColorableOption("I am Colored", new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new Vector2(ran.Next(0, OiskiEngine.Configuration.Size.x), ran.Next(0, OiskiEngine.Configuration.Size.y)));
            //ColorableOption option10 = new ColorableOption("I am Colored", new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new Vector2(ran.Next(0, OiskiEngine.Configuration.Size.x), ran.Next(0, OiskiEngine.Configuration.Size.y)));
            //ColorableOption option11 = new ColorableOption("I am Colored", new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new Vector2(ran.Next(0, OiskiEngine.Configuration.Size.x), ran.Next(0, OiskiEngine.Configuration.Size.y)));
            //ColorableOption option12 = new ColorableOption("I am Colored", new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new Vector2(ran.Next(0, OiskiEngine.Configuration.Size.x), ran.Next(0, OiskiEngine.Configuration.Size.y)));
            //ColorableOption option13 = new ColorableOption("I am Colored", new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new Vector2(ran.Next(0, OiskiEngine.Configuration.Size.x), ran.Next(0, OiskiEngine.Configuration.Size.y)));
            //ColorableOption option14 = new ColorableOption("I am Colored", new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new Vector2(ran.Next(0, OiskiEngine.Configuration.Size.x), ran.Next(0, OiskiEngine.Configuration.Size.y)));
            //ColorableOption option15 = new ColorableOption("I am Colored", new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new Vector2(ran.Next(0, OiskiEngine.Configuration.Size.x), ran.Next(0, OiskiEngine.Configuration.Size.y)));
            //ColorableOption option16 = new ColorableOption("I am Colored", new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new Vector2(ran.Next(0, OiskiEngine.Configuration.Size.x), ran.Next(0, OiskiEngine.Configuration.Size.y)));
            //ColorableOption option17 = new ColorableOption("I am Colored", new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new Vector2(ran.Next(0, OiskiEngine.Configuration.Size.x), ran.Next(0, OiskiEngine.Configuration.Size.y)));
            //ColorableOption option18 = new ColorableOption("I am Colored", new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new Vector2(ran.Next(0, OiskiEngine.Configuration.Size.x), ran.Next(0, OiskiEngine.Configuration.Size.y)));
            //ColorableOption option19 = new ColorableOption("I am Colored", new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new Vector2(ran.Next(0, OiskiEngine.Configuration.Size.x), ran.Next(0, OiskiEngine.Configuration.Size.y)));
            //ColorableOption option20 = new ColorableOption("I am Colored", new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new RenderColor(( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White), ( ConsoleColor ) ran.Next(( int ) ConsoleColor.Black, ( int ) ConsoleColor.White)), new Vector2(ran.Next(0, OiskiEngine.Configuration.Size.x), ran.Next(0, OiskiEngine.Configuration.Size.y)));

            OiskiEngine.ChangeRenderer(renderer);
            OiskiEngine.Run();
            #endregion
        }

        #region V10 - Input Controller: OnSelection Test
        //private static void OnEnter(object _sender)
        //{
        //    if ( MenuEngine.Input.CanWrite )
        //    {
        //        MenuEngine.Input.SetWriting(false);
        //    }
        //    else
        //    {
        //        Label sender = ( ( Label ) _sender );
        //        MenuEngine.Input.SetWriting(true);
        //        sender.Text = "I got trickered";
        //        MenuEngine.Input.SetTextInput(sender.Text);
        //    }
        //}
        #endregion

        #region V13 - Small Menu Test: Events
        //private static void InitiateMain(SelectableControl _control)
        //{
        //    RemoveMenu();

        //    Option option1 = new Option("Create Database", new Vector2(5, 10))
        //    {
        //        SelectedIndex = new Vector2(0, 0)
        //    };

        //    option1.OnSelect += InitiateCreate;

        //    option1.BorderStyle(BorderArea.Horizontal, '~');
        //    Option option2 = new Option("Attach Database", new Vector2(5, 13))
        //    {
        //        SelectedIndex = new Vector2(0, 1)
        //    };

        //    option2.OnSelect += (s) => s.Text = "I got triggered";

        //    Option option3 = new Option("Delete Database", new Vector2(5, 16))
        //    {
        //        SelectedIndex = new Vector2(0, 2)
        //    };

        //    option3.OnSelect += (s) => s.Text = "I got triggered";

        //    TextField field1 = new TextField("Database Name", new Vector2(50, 10))
        //    {
        //        SelectedIndex = new Vector2(0, 3),
        //        EraseTextOnSelect = true
        //    };
        //}

        //private static void InitiateCreate(SelectableControl _control)
        //{
        //    RemoveMenu();

        //    TextField dbName_field = new TextField("DB Name", new Vector2(5, 10))
        //    {
        //        SelectedIndex = new Vector2(0, 0),
        //        EraseTextOnSelect = true,
        //        ResetAfterFirstWrite = true
        //    };

        //    TextField dbPath = new TextField("Path", new Vector2(5, 13))
        //    {
        //        SelectedIndex = new Vector2(0, 1),
        //        EraseTextOnSelect = true
        //    };

        //    dbName_field.BorderStyle(BorderArea.Horizontal, '~');

        //    Option back = new Option("Back", new Vector2(5, 16))
        //    {
        //        SelectedIndex = new Vector2(0, 2)
        //    };

        //    back.OnSelect += InitiateMain;
        //}

        //private static void AtTarget(SelectableControl _sender)
        //{
        //    foreach ( SelectableControl control in OiskiEngine.Controls.GetSelectableControls )
        //    {
        //        if ( control == _sender )
        //        {
        //            _sender.BorderStyle(BorderArea.Horizontal, '~');
        //        }
        //        else /*if ( control is SelectableControl sControl )*/
        //        {
        //            control.BorderStyle(BorderArea.Horizontal, '-');
        //        }
        //    }
        //}

        //private static void RemoveMenu()
        //{
        //    for ( int i = 0; i < OiskiEngine.Controls.GetSelectableControls.Count; i++ )
        //    {
        //        OiskiEngine.Controls.RemoveControl(OiskiEngine.Controls.GetSelectableControls[i]);
        //        i = -1;
        //    }
        //}
        #endregion
    }
}
