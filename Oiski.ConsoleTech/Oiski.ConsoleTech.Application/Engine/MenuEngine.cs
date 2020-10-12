using Oiski.ConsoleTech.OiskiEngine.Controls;
using Oiski.ConsoleTech.OiskiEngine.Input;
using Oiski.ConsoleTech.OiskiEngine.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace Oiski.ConsoleTech.OiskiEngine
{
    public static class MenuEngine
    {
        private static readonly object lockObject = new object();

        internal static bool DEBUGMODE { get; set; } = false;
        internal static Stopwatch TimeSinceStart { get; private set; } = null;

        internal static Renderer Renderer { get; } = new Renderer();

        public static RenderConfiguration Configuration { get; } = new RenderConfiguration(new Vector2(Console.WindowWidth, Console.WindowHeight), '+', '|', '-');

        public static InputController Input { get; } = new InputController();

        internal static List<Control> Controls { get; } = new List<Control>();

        public static void AddControl (Control _control)
        {
            lock ( lockObject )
            {
                Controls.Add(_control);
            }
        }

        public static bool RemoveControl (Control _control)
        {
            bool wasRemoved = false;
            lock ( lockObject )
            {
                wasRemoved = Controls.Remove(_control);
            }
            return wasRemoved;
        }

        public static Control FindControl (Predicate<Control> _match)
        {
            return Controls.Find(_match);
        }

        public static SelectableControl FindControl (Vector2 _selectedIndex)
        {
            foreach ( SelectableControl control in Controls )
            {
                if ( control.SelectedIndex == _selectedIndex )
                {
                    return control;
                }
            }

            return null;
        }

        private static void InsertControls ()
        {
            Renderer.InitRenderer();

            lock ( lockObject )
            {
                Controls.OrderBy(control => control.ZIndex);

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
            }

            Renderer.Render();
        }

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
            #region DEBUG Values
            string infoOutput;
            Label threadInfo = null;

            TimeSinceStart = Stopwatch.StartNew();

            string conInfo;
            Label conditionValues = null;
            #endregion

            #region DEBUG Functionality
            if ( DEBUGMODE )
            {
                infoOutput = $">Thread Name: {Thread.CurrentThread.Name}<|>Time Since Start: {TimeSinceStart.ElapsedMilliseconds / 1000} Seconds<";
                threadInfo = new Label(infoOutput, new Vector2(Console.WindowWidth - infoOutput.Length - 4, 0));

                conInfo = $">Selected: {( ( Input.CanSelect ) ? ( $"{Input.Selected}" ) : ( "Can't Select" ) )}<|>Navigation: {( ( Input.EnableNavigation ) ? ( "Enabled" ) : ( "Disabled" ) )}<|>Can Write: {Input.CanWrite}<";
                conditionValues = new Label(conInfo, new Vector2(Console.WindowWidth - conInfo.Length - 4, 6));
            }
            #endregion

            Input.ListenForInput();

            do
            {
                #region DEBUG Functionality
                if ( DEBUGMODE && TimeSinceStart != null && threadInfo != null && conditionValues != null )
                {
                    infoOutput = $">Thread Name: {Thread.CurrentThread.Name}<|>Time Since Start: {TimeSinceStart.ElapsedMilliseconds / 1000} Seconds<";
                    threadInfo.Position = new Vector2(Console.WindowWidth - infoOutput.Length - 4, 0);
                    threadInfo.Text = infoOutput;

                    conInfo = $">Selected: {( ( Input.CanSelect ) ? ( $"{Input.Selected}" ) : ( "Can't Select" ) )}<|>Navigation: {( ( Input.EnableNavigation ) ? ( "Enabled" ) : ( "Disabled" ) )}<|>Can Write: {Input.CanWrite}<";
                    conditionValues.Position = new Vector2(Console.WindowWidth - conInfo.Length - 4, 6);
                    conditionValues.Text = conInfo;
                }
                else if ( threadInfo != null )
                {
                    RemoveControl(threadInfo);
                    threadInfo = null;

                    MenuEngine.RemoveControl(conditionValues);
                    conditionValues = null;
                }
                else if ( DEBUGMODE && threadInfo == null && conditionValues == null )
                {
                    infoOutput = $">Thread Name: {Thread.CurrentThread.Name}<|>Time Since Start: {TimeSinceStart.ElapsedMilliseconds / 1000} Seconds<";
                    threadInfo = new Label(infoOutput, new Vector2(Console.WindowWidth - infoOutput.Length - 4, 0));

                    conInfo = $">Selected: {( ( Input.CanSelect ) ? ( $"{Input.Selected}" ) : ( "Can't Select" ) )}<|>Navigation: {( ( Input.EnableNavigation ) ? ( "Enabled" ) : ( "Disabled" ) )}<|>Can Write: {Input.CanWrite}<";
                    conditionValues = new Label(conInfo, new Vector2(Console.WindowWidth - conInfo.Length - 4, 6));
                }
                #endregion

                InsertControls();
            } while ( true );
        }
    }
}
