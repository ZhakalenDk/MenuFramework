using Oiski.ConsoleTech.OiskiEngine.Controls;
using Oiski.ConsoleTech.OiskiEngine.Engine.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Oiski.ConsoleTech.OiskiEngine.Input
{
    public class InputController
    {
        private readonly object lockObject = new object();
        public int CurrentSelectedIndex_X { get; private set; }
        public int CurrentSelectedIndex_Y { get; private set; }
        public bool Selected { get; private set; } = false;

        public NavController Navigation { get; } = new NavController();

        public bool EnableNavigation { get; set; } = true;
        public bool CanSelect { get; set; } = true;

        public ConsoleKeyInfo GetKeyInfo ()
        {
            return Console.ReadKey();
        }

        public char GetChar ()
        {
            return Console.ReadKey().KeyChar;
        }

        public string GetString ()
        {
            return Console.ReadLine();
        }

        public void ListenForInput ()
        {
            Thread rendereThread = new Thread(Start)
            {
                Name = "Input",
                Priority = ThreadPriority.AboveNormal
            };

            rendereThread.Start();
        }

        private void Start ()
        {
            var sw = Stopwatch.StartNew();
            string infoOutput = $">Thread Name: {Thread.CurrentThread.Name}<|>Time Since Start: {sw.ElapsedMilliseconds / 1000} Seconds<";
            Label threadInfo = new Label(infoOutput, new Vector2(Console.WindowWidth - infoOutput.Length - 4, 3));

            do
            {
                infoOutput = $">Thread Name: {Thread.CurrentThread.Name}<|>Idle Time: {sw.ElapsedMilliseconds / 1000} Seconds<|>IsSelected: {Selected}<|>Selected Index: x({CurrentSelectedIndex_X}) Y({CurrentSelectedIndex_Y})<";
                threadInfo.Position = new Vector2(Console.WindowWidth - infoOutput.Length - 4, 3);
                threadInfo.Text = infoOutput;
                sw.Restart();

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if ( EnableNavigation )
                {


                    if ( keyInfo.Key == Navigation.Up )
                    {
                        lock ( lockObject )
                        {
                            MenuEngine.Input.CurrentSelectedIndex_Y--;
                        }

                    }

                    if ( keyInfo.Key == Navigation.Down )
                    {
                        lock ( lockObject )
                        {
                            MenuEngine.Input.CurrentSelectedIndex_Y++;
                        }
                    }

                    if ( keyInfo.Key == Navigation.Left )
                    {
                        lock ( lockObject )
                        {
                            MenuEngine.Input.CurrentSelectedIndex_X--;
                        }
                    }

                    if ( keyInfo.Key == Navigation.Right )
                    {
                        lock ( lockObject )
                        {
                            MenuEngine.Input.CurrentSelectedIndex_X++;
                        }
                    }
                }

                if ( CanSelect )
                {
                    if ( keyInfo.Key == Navigation.Select )
                    {
                        lock ( lockObject )
                        {
                            Selected = true;
                        }
                    }
                    else
                    {
                        lock ( lockObject )
                        {
                            Selected = false;
                        }
                    }
                }

            } while ( true );
        }
    }
}