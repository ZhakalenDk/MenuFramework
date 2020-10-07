using Oiski.ConsoleTech.Application.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Timers;

namespace Oiski.ConsoleTech.Application
{
    public class MenuEngine
    {
        protected Renderer Renderer { get; } = new Renderer();

        public RenderConfiguration Configuration { get; } = new RenderConfiguration(new Vector2(Console.WindowWidth, Console.WindowHeight), '+', '|', '-');

        protected List<Control> Controls { get; } = new List<Control>();

        public void AddControl (Control _control)
        {
            Controls.Add(_control);
        }

        public bool RemoveControl (Control _control)
        {
            return Controls.Remove(_control);
        }

        private void DrawControls ()
        {
            Renderer.InitRenderer();
            foreach ( Control control in Controls )
            {
                int positionX = control.Position.x;
                int positionY = control.Position.y;
                for ( int y = 0; y < control.Size.y; y++ )
                {
                    for ( int x = 0; x < control.Size.x; x++ )
                    {
                        Renderer.InsertAt(new Vector2(positionX++, positionY), control.Build()[x, y]);
                    }
                    positionX = control.Position.x;
                    positionY++;
                }
            }

            Renderer.Render();
        }

        public void Run ()
        {
            var sw = Stopwatch.StartNew();
            Label threadInfo = new Label($">Thread Name: {Thread.CurrentThread.Name}<|>Time Since Start: {sw.ElapsedMilliseconds / 1000} Seconds<", new Vector2(30, 0));
            AddControl(threadInfo);
            do
            {
                threadInfo.Text = $">Thread Name: {Thread.CurrentThread.Name}<|>Time Since Start: {sw.ElapsedMilliseconds / 1000} Seconds<";
                DrawControls();
            } while ( true );

        }
    }
}
