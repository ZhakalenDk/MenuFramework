using Oiski.ConsoleTech.Engine.Controls;
using Oiski.ConsoleTech.Engine.Input;
using Oiski.ConsoleTech.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Oiski.ConsoleTech.Engine
{
    /// <summary>
    /// Defines an engine that can registrer input from users and render visual parts to the console in parallel 
    /// </summary>
    public static class OiskiEngine
    {
        /// <summary>
        /// Use this to lock internal values when changed.
        /// </summary>
        private static readonly object lockObject = new object();

        /// <summary>
        /// If true this will enable debug mode.
        /// </summary>
        internal static bool DEBUGMODE { get; set; } = false;

        /// <summary>
        /// Monitors the time since the <see cref="OiskiEngine"/> was started.
        /// </summary>
        internal static Stopwatch TimeSinceStart { get; private set; } = null;

        /// <summary>
        /// The <see cref="Rendering.Renderer"/> that will be used to render the rendering loops for the <see cref="OiskiEngine"/>
        /// </summary>
        internal static Renderer Renderer { get; set; } = new Renderer();

        /// <summary>
        /// The confiuration that is used to set the how the <see cref="Rendering.Renderer"/> behaves
        /// </summary>
        public static RenderConfiguration Configuration { get; private set; } = new RenderConfiguration(new Vector2(Console.WindowWidth, Console.WindowHeight), '+', '|', '-');

        /// <summary>
        /// THe <see cref="OiskiEngine"/>s <see cref="InputController"/> that will listen and registrer input from an user.
        /// </summary>
        public static InputController Input { get; } = new InputController();

        /// <summary>
        /// Contains all the controls that are attached directly to the <see cref="OiskiEngine"/>
        /// </summary>
        public static ControlCollection Controls { get; } = new ControlCollection();

        ///// <summary>
        ///// Contains all <see cref="Control"/>s that are currently present in the render heirachy.
        ///// </summary>
        //internal static List<Control> Controls { get; } = new List<Control>();

        //public static void AddControl (Control _control)
        //{
        //    lock ( lockObject )
        //    {
        //        Controls.Add(_control);
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="_control"></param>
        ///// <returns><see langword="true"/> if the <see cref="Control"/> could be removed, otherwise <see langword="false"/></returns>
        //public static bool RemoveControl (Control _control)
        //{
        //    bool wasRemoved = false;
        //    lock ( lockObject )
        //    {
        //        wasRemoved = Controls.Remove(_control);
        //    }
        //    return wasRemoved;
        //}

        ///// <summary>
        ///// Search the list of <see cref="Control"/>s for a <see cref="Control"/> that fits the <paramref name="_match"/> conditions.
        ///// </summary>
        ///// <param name="_match"></param>
        ///// <returns>The first occurence that matches the predicate. If not <see cref="Control"/> is found it will return <see langword="null"/></returns>
        //public static Control FindControl (Predicate<Control> _match)
        //{
        //    return Controls.Find(_match);
        //}

        ///// <summary>
        ///// Search for a <see cref="SelectableControl"/> based on the <paramref name="_selectedIndex"/>
        ///// </summary>
        ///// <param name="_selectedIndex"></param>
        ///// <returns>The first occurence that matches the <paramref name="_selectedIndex"/>. If no match is found it will return <see langword="null"/></returns>
        //public static SelectableControl FindControl (Vector2 _selectedIndex)
        //{
        //    foreach ( var control in Controls )
        //    {
        //        if ( control is SelectableControl sControl && sControl.SelectedIndex == _selectedIndex )
        //        {
        //            return sControl;
        //        }
        //    }

        //    return null;
        //}

        /// <summary>
        /// Change the <see cref="Renderer"/> for the <see cref="OiskiEngine"/>
        /// <br/>
        /// <strong>Note:</strong> The default render will be sufficient for most cases.
        /// </summary>
        /// <param name="_renderer"></param>
        public static void ChangeRenderer(Renderer _renderer)
        {
            lock ( lockObject )
            {
                Renderer = _renderer;
            }
        }

        /// <summary>
        /// Insert all <see cref="Control"/>s in the <see cref="Controls"/> <see cref="List{T}"/> into the <see cref="Renderer.Grid"/>
        /// </summary>
        private static void InsertControls()
        {
            lock ( lockObject )
            {
                Renderer.Configuration = Configuration;
                Renderer.InitRenderer();
                Controls.GetControls.OrderByDescending(control => control.ZIndex);

                for ( int i = 0; i < Controls.GetControls.Count; i++ )
                {
                    if ( Controls[i].Render )
                    {
                        int positionX = Controls[i].Position.x;
                        int positionY = Controls[i].Position.y;
                        for ( int y = 0; y < Controls[i].Size.y; y++ )
                        {
                            for ( int x = 0; x < Controls[i].Size.x; x++ )
                            {

                                Renderer.InsertAt(new Vector2(positionX++, positionY), Controls[i].GetBuild[x, y]);
                            }
                            positionX = Controls[i].Position.x;
                            positionY++;
                        }
                    }
                }
            }

            Renderer.Render();
        }

        /// <summary>
        /// Begin the execution of the <see cref="OiskiEngine"/> and it's internal functionalities
        /// </summary>
        public static void Run()
        {
            Thread rendereThread = new Thread(Start)
            {
                Name = "Renderer",
                Priority = ThreadPriority.AboveNormal
            };

            rendereThread.Start();
        }

        /// <summary>
        /// Will set off the <see cref="OiskiEngine"/> loop
        /// </summary>
        private static void Start()
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
                threadInfo = new Label(infoOutput, new Vector2(Console.WindowWidth - infoOutput.Length - 4, 0))
                {
                    ZIndex = -1
                };

                conInfo = $">Can select: {( ( Input.CanSelect ) ? ( "Enabled" ) : ( "Disabled" ) )}<|>Navigation: {( ( Input.NavigationEnabled ) ? ( "Enabled" ) : ( "Disabled" ) )}<|>Can Write: {Input.CanWrite}<";
                conditionValues = new Label(conInfo, new Vector2(Console.WindowWidth - conInfo.Length - 4, 6))
                {
                    ZIndex = -1
                };
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

                    conInfo = $">Can Select: {( ( Input.CanSelect ) ? ( "Enabled" ) : ( "Disabled" ) )}<|>Navigation: {( ( Input.NavigationEnabled ) ? ( "Enabled" ) : ( "Disabled" ) )}<|>Can Write: {Input.CanWrite}<";
                    conditionValues.Position = new Vector2(Console.WindowWidth - conInfo.Length - 4, 6);
                    conditionValues.Text = conInfo;
                }
                else if ( threadInfo != null )
                {
                    Controls.RemoveControl(threadInfo);
                    threadInfo = null;

                    Controls.RemoveControl(conditionValues);
                    conditionValues = null;
                }
                else if ( DEBUGMODE && threadInfo == null && conditionValues == null )
                {
                    infoOutput = $">Thread Name: {Thread.CurrentThread.Name}<|>Time Since Start: {TimeSinceStart.ElapsedMilliseconds / 1000} Seconds<";
                    threadInfo = new Label(infoOutput, new Vector2(Console.WindowWidth - infoOutput.Length - 4, 0))
                    {
                        ZIndex = -1
                    };

                    conInfo = $">Can Select: {( ( Input.CanSelect ) ? ( "Enabled" ) : ( "Disabled" ) )}<|>Navigation: {( ( Input.NavigationEnabled ) ? ( "Enabled" ) : ( "Disabled" ) )}<|>Can Write: {Input.CanWrite}<";
                    conditionValues = new Label(conInfo, new Vector2(Console.WindowWidth - conInfo.Length - 4, 6))
                    {
                        ZIndex = -1
                    };
                }
                #endregion

                InsertControls();
            } while ( true );
        }
    }
}
