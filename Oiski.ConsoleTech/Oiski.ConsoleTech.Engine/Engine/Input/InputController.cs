using Oiski.ConsoleTech.Engine.Controls;
using System;
using System.Diagnostics;
using System.Threading;

namespace Oiski.ConsoleTech.Engine.Input
{
    /// <summary>
    /// Defines a threaded controller for retrieving and applying user input in a <see cref="Console"/> application
    /// </summary>
    public class InputController
    {
        /// <summary>
        /// Use this to <see langword="lock"/> the internal <see cref="InputController"/> values when changes happen
        /// </summary>
        private readonly object lockObject = new object();
        /// <summary>
        /// The index on the x-axis of the selection system
        /// </summary>
        private int currentSelectedIndex_X;
        /// <summary>
        /// The index on the y-axis of the selection system
        /// </summary>
        private int currentSelectedIndex_Y;

        /// <summary>
        /// The index that defines the current position of the selection marker
        /// </summary>
        public Vector2 GetSelectedIndex
        {
            get
            {
                return new Vector2(currentSelectedIndex_X, currentSelectedIndex_Y);
            }
        }
        /// <summary>
        /// The event that is triggered when a <see cref="SelectableControl"/> is targeted by the selection system.
        /// <br/>
        /// <strong>Note:</strong> This is triggered <strong>before</strong> any other event originated in this <see langword="class"/>
        /// </summary>
        public Action<SelectableControl> AtTarget { get; set; }
        /// <summary>
        /// The text input gathered while <see cref="CanWrite"/> is active.
        /// <br/>
        /// Use this retrieve <see cref="string"/> input from the user through the <see cref="InputController"/>
        /// </summary>
        public string TextInput { get; protected set; } = string.Empty;
        /// <summary>
        /// The keys used to navigate the selection system.
        /// </summary>
        public KeyBindings NavigationKeys { get; } = new KeyBindings();
        /// <summary>
        /// If <see langword="true"/> input will be enabled for the <see cref="InputController"/>
        /// </summary>
        public bool InputEnabled { get; private set; } = true;
        /// <summary>
        /// If <see langword="true"/> navigation will be enabled for the <see cref="InputController"/>
        /// </summary>
        public bool NavigationEnabled { get; private set; } = true;
        /// <summary>
        /// If <see langword="true"/> the <see cref="InputController"/> can recieve input on the horizontal navigational axis
        /// </summary>
        public bool HorizontalNavigationEnabled { get; private set; } = true;
        /// <summary>
        /// If <see langword="true"/> the <see cref="InputController"/> can recieve input on the vertical navigational axis
        /// </summary>
        public bool VerticalNavigationEnabled { get; private set; } = true;
        /// <summary>
        /// If <see langword="true"/> the selection system won't go negative on the X-axis
        /// </summary>
        public bool HorizontalClamp { get; private set; } = true;
        /// <summary>
        /// If <see langword="true"/> the selection system won't go negative on the Y-axis
        /// </summary>
        public bool VerticalClamp { get; private set; } = true;
        /// <summary>
        /// If <see langword="true"/> the <see cref="InputController"/> will be able to select a <see cref="SelectableControl"/> on the selection system
        /// </summary>
        public bool CanSelect { get; private set; } = true;
        /// <summary>
        /// If <see langword="true"/> the <see cref="InputController"/> can gather text input from a user.
        /// <strong>Note:</strong> Use <see cref="TextInput"/> to retrieve the input
        /// </summary>
        public bool CanWrite { get; private set; } = false;

        /// <summary>
        /// Enables the <see cref="InputController"/> for recieving input
        /// </summary>
        /// <param name="_enable"></param>
        public void EnableInput(bool _enable)
        {
            lock ( lockObject )
            {
                InputEnabled = _enable;
            }
        }

        /// <summary>
        /// When <paramref name="_enable"/> is <see langword="true"/> the <see cref="InputController"/> can use the <see cref="NavigationKeys"/> to increase or decrease the current selected index on either axis
        /// </summary>
        /// <param name="_enable"></param>
        public void SetNavigation(bool _enable)
        {
            lock ( lockObject )
            {
                NavigationEnabled = _enable;
            }
        }

        /// <summary>
        /// When <paramref name="_enable"/> is <see langword="true"/> the <see cref="InputController"/> can use the <see cref="NavigationKeys"/> to increase or decrease the current selected index on the <paramref name="_axis"/>
        /// </summary>
        /// <param name="_axis"></param>
        /// <param name="_enable"></param>
        public void SetNavigation(string _axis, bool _enable)
        {
            switch ( _axis.ToLower() )
            {
                case "horizontal":
                    HorizontalNavigationEnabled = _enable;
                    break;
                case "vertical":
                    VerticalNavigationEnabled = _enable;
                    break;
                default:
                    throw new Exception($"{_axis} is not an axis!");
            }
        }

        /// <summary>
        /// Will clamp the value on the <paramref name="_axis"/> so the current selection index can't go negative or higher than the amount of <strong>directly</strong> attached <see cref="SelectableControl"/>s in the <see cref="OiskiEngine.Controls"/> collectons
        /// </summary>
        /// <param name="_axis"></param>
        /// <param name="_enable"></param>
        public void SetClamp(string _axis, bool _enable)
        {
            switch ( _axis.ToLower() )
            {
                case "horizontal":
                    HorizontalClamp = _enable;
                    break;
                case "vertical":
                    VerticalClamp = _enable;
                    break;
                default:
                    throw new Exception($"{_axis} is not an axis!");
            }
        }

        /// <summary>
        /// If <paramref name="_canSelect"/> is <see langword="true"/> the <see cref="InputController"/> can select a <see cref="SelectableControl"/> at the selection index target
        /// </summary>
        /// <param name="_canSelect"></param>
        public void SetSelect(bool _canSelect)
        {
            lock ( lockObject )
            {
                CanSelect = _canSelect;
            }
        }

        /// <summary>
        /// If <paramref name="_canWrite"/> is <see langword="true"/> the <see cref="InputController"/> will be able to recieve text input
        /// </summary>
        /// <param name="_canWrite"></param>
        public void SetWriting(bool _canWrite)
        {
            lock ( lockObject )
            {
                CanWrite = _canWrite;
            }
        }

        /// <summary>
        /// Set the <see langword="value"/> of <see cref="TextInput"/> to <paramref name="_text"/>
        /// </summary>
        /// <param name="_text"></param>
        /// <returns></returns>
        public string SetTextInput(string _text)
        {
            lock ( lockObject )
            {
                TextInput = _text;
            }

            return TextInput;
        }

        /// <summary>
        /// Reset the selected index back to zero no both axises
        /// </summary>
        public void ResetSlection()
        {
            currentSelectedIndex_X = 0;
            currentSelectedIndex_Y = 0;
        }

        private bool IsSpecialCharacter(char _char)
        {
            if ( ( _char >= '!' && _char <= '/' ) || ( _char >= ':' && _char <= '@' ) || ( _char >= '[' && _char <= '`' ) || ( _char >= '{' && _char <= '~' ) )
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Begin listening for user input
        /// </summary>
        public void ListenForInput()
        {
            Thread rendereThread = new Thread(Start)
            {
                Name = "Input",
                Priority = ThreadPriority.AboveNormal
            };

            rendereThread.Start();
        }

        /// <summary>
        /// Begin the <see cref="InputController"/> loop
        /// </summary>
        protected virtual void Start()
        {
            #region DEBUG Values
            Stopwatch sw = null;
            string infoOutput;
            Label threadInfo = null;

            //string conInfo;
            //Label conditionValues = null;
            #endregion

            if ( InputEnabled )
            {
                #region DEBUG Functionality
                if ( OiskiEngine.DEBUGMODE )
                {
                    sw = Stopwatch.StartNew();
                    infoOutput = $">Thread Name: {Thread.CurrentThread.Name}<|>Time Between Input: {sw.ElapsedMilliseconds / 1000} Seconds<|>Selected Index: X({currentSelectedIndex_X}) Y({currentSelectedIndex_Y})<";
                    threadInfo = new Label(infoOutput, new Vector2(Console.WindowWidth - infoOutput.Length - 4, 3))
                    {
                        ZIndex = -1
                    };
                    //conInfo = $">Selected: {( ( CanSelect ) ? ( $"{Selected}" ) : ( "Can't Select" ) )}<|>Navigation: {( ( EnableNavigation ) ? ( "Enabled" ) : ( "Disabled" ) )}<|>Can Write: {CanWrite}<";
                    //conditionValues = new Label(conInfo, new Vector2(Console.WindowWidth - conInfo.Length - 4, 6));
                }
                #endregion

                do
                {
                    #region DEBUG Functionality
                    if ( OiskiEngine.DEBUGMODE && sw != null && threadInfo != null )
                    {
                        infoOutput = $">Thread Name: {Thread.CurrentThread.Name}<|>Time Between Input: {sw.ElapsedMilliseconds / 1000} Seconds<|>Selected Index: X({currentSelectedIndex_X}) Y({currentSelectedIndex_Y})<";
                        threadInfo.Position = new Vector2(Console.WindowWidth - infoOutput.Length - 4, 3);
                        threadInfo.Text = infoOutput;
                        sw.Restart();
                    }
                    else if ( threadInfo != null )
                    {
                        sw = null;
                        OiskiEngine.Controls.RemoveControl(threadInfo);
                        threadInfo = null;
                    }
                    else if ( OiskiEngine.DEBUGMODE && threadInfo == null && sw == null )
                    {
                        sw = Stopwatch.StartNew();
                        infoOutput = $">Thread Name: {Thread.CurrentThread.Name}<|>Time Between Input: {sw.ElapsedMilliseconds / 1000} Seconds<|>Selected Index: X({currentSelectedIndex_X}) Y({currentSelectedIndex_Y})<";
                        threadInfo = new Label(infoOutput, new Vector2(Console.WindowWidth - infoOutput.Length - 4, 3))
                        {
                            ZIndex = -1
                        };
                    }
                    #endregion

                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if ( keyInfo.Key == NavigationKeys.Debug )
                    {
                        OiskiEngine.DEBUGMODE = !OiskiEngine.DEBUGMODE;
                    }

                    #region Writing Reset
                    if ( !CanWrite )
                    {
                        SetTextInput(string.Empty);
                    }
                    #endregion

                    #region Navigation
                    if ( NavigationEnabled )
                    {
                        if ( VerticalNavigationEnabled )
                        {
                            if ( keyInfo.Key == NavigationKeys.Up )
                            {
                                lock ( lockObject )
                                {
                                    currentSelectedIndex_Y--;

                                    if ( VerticalClamp && currentSelectedIndex_Y < 0 )
                                    {
                                        currentSelectedIndex_Y++;
                                    }
                                }

                            }

                            if ( keyInfo.Key == NavigationKeys.Down )
                            {
                                lock ( lockObject )
                                {
                                    currentSelectedIndex_Y++;

                                    if ( VerticalClamp && currentSelectedIndex_Y > OiskiEngine.Controls.GetSelectableControls.Count - 1 )
                                    {
                                        currentSelectedIndex_Y--;
                                    }
                                }
                            }
                        }

                        if ( HorizontalNavigationEnabled )
                        {
                            if ( keyInfo.Key == NavigationKeys.Left )
                            {
                                lock ( lockObject )
                                {
                                    currentSelectedIndex_X--;
                                }
                            }

                            if ( keyInfo.Key == NavigationKeys.Right )
                            {
                                lock ( lockObject )
                                {
                                    currentSelectedIndex_X++;
                                }
                            }
                        }

                        lock ( lockObject )
                        {
                            SelectableControl control = OiskiEngine.Controls.FindControl(GetSelectedIndex);

                            if ( control != null )
                            {
                                AtTarget?.Invoke(control);
                            }
                        }
                    }
                    #endregion

                    #region Selection
                    if ( CanSelect )
                    {
                        if ( keyInfo.Key == NavigationKeys.Select )
                        {
                            lock ( lockObject )
                            {
                                SelectableControl control = OiskiEngine.Controls.FindControl(GetSelectedIndex);

                                if ( control != null )
                                {
                                    control.IsSelected = true;
                                    control.HandleSelectEvent();

                                }
                            }
                        }
                    }
                    #endregion

                    #region Writing
                    if ( CanWrite )
                    {
                        if ( keyInfo.Key == ConsoleKey.Backspace )
                        {
                            if ( TextInput.Length > 0 )
                            {
                                lock ( lockObject )
                                {
                                    TextInput = TextInput.Remove(TextInput.Length - 1);
                                }
                            }
                        }
                        else
                        {

                            lock ( lockObject )
                            {
                                if ( ( char.IsLetter(keyInfo.KeyChar) || char.IsWhiteSpace(keyInfo.KeyChar) || IsSpecialCharacter(keyInfo.KeyChar) ) && keyInfo.Key != NavigationKeys.Select )
                                {
                                    TextInput += keyInfo.KeyChar;
                                }

                            }
                        }


                    }
                    #endregion

                } while ( true );
            }
        }
    }
}