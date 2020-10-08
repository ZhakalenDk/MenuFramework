using Oiski.ConsoleTech.Application.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Timers;

namespace Oiski.ConsoleTech.Application
{
    public static class MenuEngine
    {
        internal static Renderer Renderer { get; } = new Renderer();

        public static RenderConfiguration Configuration { get; } = new RenderConfiguration(new Vector2(Console.WindowWidth, Console.WindowHeight), '+', '|', '-');

        internal static List<Control> Controls { get; } = new List<Control>();

        public static void AddControl (Control _control)
        {
            Controls.Add(_control);
        }

        public static bool RemoveControl (Control _control)
        {
            return Controls.Remove(_control);
        }

        public static Control FindControl (int _indexID)
        {
            for ( int i = 0; i < Controls.Count; i++ )
            {
                if ( Controls[i].IndexID == _indexID )
                {
                    return Controls[i];
                }
            }

            return null;
        }

        private static void DrawControls ()
        {
            Renderer.InitRenderer();
            for ( int i = 0; i < Controls.Count; i++ )
            {
                int positionX = Controls[i].Position.x;
                int positionY = Controls[i].Position.y;
                for ( int y = 0; y < Controls[i].Size.y; y++ )
                {
                    for ( int x = 0; x < Controls[i].Size.x; x++ )
                    {
                        Renderer.InsertAt(new Vector2(positionX++, positionY), Controls[i].Build()[x, y]);
                    }
                    positionX = Controls[i].Position.x;
                    positionY++;
                }
            }

            Renderer.Render();
        }

        private static SelectableControl SelectedControl;

        public static void Run ()
        {
            Thread rendereThread = new Thread(Start)
            {
                Name = "Renderer",
                Priority = ThreadPriority.AboveNormal
            };

            rendereThread.Start();
        }

        private static void Start ()
        {
            var sw = Stopwatch.StartNew();
            string infoOutput = $">Thread Name: {Thread.CurrentThread.Name}<|>Time Since Start: {sw.ElapsedMilliseconds / 1000} Seconds<";
            Label threadInfo = new Label(infoOutput, new Vector2(Console.WindowWidth - infoOutput.Length - 4, 0));
            do
            {
                infoOutput = $">Thread Name: {Thread.CurrentThread.Name}<|>Time Since Start: {sw.ElapsedMilliseconds / 1000} Seconds<";
                threadInfo.Position = new Vector2(Console.WindowWidth - infoOutput.Length - 4, 0);
                threadInfo.Text = infoOutput;
                SelectedControl?.HandleMe();
                DrawControls();
            } while ( true );
        }
    }
}
