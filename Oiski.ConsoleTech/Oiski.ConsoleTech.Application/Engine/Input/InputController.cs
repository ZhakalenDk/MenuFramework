using Oiski.ConsoleTech.OiskiEngine.Controls;
using Oiski.ConsoleTech.OiskiEngine.Engine.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace Oiski.ConsoleTech.OiskiEngine.Input
{
    public class InputController
    {
        private readonly object lockObject = new object();
        private int currentSelectedIndex_X;
        private int currentSelectedIndex_Y;
        public Vector2 GetSelectedIndex
        {
            get
            {
                return new Vector2(currentSelectedIndex_X, currentSelectedIndex_Y);
            }
        }
        //public bool Selected { get; private set; } = false;
        public Action OnSelect { get; set; }
        public string TextInput { get; protected set; } = string.Empty;

        public KeyBindings NavigationKeys { get; } = new KeyBindings();

        public bool InputEnabled { get; private set; } = true;
        public bool EnableNavigation { get; private set; } = true;
        public bool CanSelect { get; private set; } = true;
        public bool CanWrite { get; private set; } = false;

        public void EnableInput (bool _enable)
        {
            lock ( lockObject )
            {
                InputEnabled = _enable;
            }
        }

        public void SetNavigation (bool _enable)
        {
            lock ( lockObject )
            {
                EnableNavigation = _enable;
            }
        }

        public void SetSelect (bool _canSelect)
        {
            lock ( lockObject )
            {
                CanSelect = _canSelect;
            }
        }

        public void SetWriting (bool _canWrite)
        {
            lock ( lockObject )
            {
                CanWrite = _canWrite;
            }
        }

        public string SetTextInput (string _text)
        {
            lock ( lockObject )
            {
                TextInput = _text;
            }

            return TextInput;
        }

        private bool IsSpecialCharacter (char _char)
        {
            if ( ( _char >= '!' && _char <= '/' ) || ( _char >= ':' && _char <= '@' ) || ( _char >= '[' && _char <= '`' ) || ( _char >= '{' && _char <= '~' ) )
            {
                return true;
            }

            return false;
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

        protected virtual void Start ()
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
                if ( MenuEngine.DEBUGMODE )
                {
                    sw = Stopwatch.StartNew();
                    infoOutput = $">Thread Name: {Thread.CurrentThread.Name}<|>Time Between Input: {sw.ElapsedMilliseconds / 1000} Seconds<|>Selected Index: X({currentSelectedIndex_X}) Y({currentSelectedIndex_Y})<";
                    threadInfo = new Label(infoOutput, new Vector2(Console.WindowWidth - infoOutput.Length - 4, 3));

                    //conInfo = $">Selected: {( ( CanSelect ) ? ( $"{Selected}" ) : ( "Can't Select" ) )}<|>Navigation: {( ( EnableNavigation ) ? ( "Enabled" ) : ( "Disabled" ) )}<|>Can Write: {CanWrite}<";
                    //conditionValues = new Label(conInfo, new Vector2(Console.WindowWidth - conInfo.Length - 4, 6));
                }
                #endregion

                do
                {
                    #region DEBUG Functionality
                    if ( MenuEngine.DEBUGMODE && sw != null && threadInfo != null )
                    {
                        infoOutput = $">Thread Name: {Thread.CurrentThread.Name}<|>Time Between Input: {sw.ElapsedMilliseconds / 1000} Seconds<|>Selected Index: X({currentSelectedIndex_X}) Y({currentSelectedIndex_Y})<";
                        threadInfo.Position = new Vector2(Console.WindowWidth - infoOutput.Length - 4, 3);
                        threadInfo.Text = infoOutput;
                        sw.Restart();
                    }
                    else if ( threadInfo != null )
                    {
                        sw = null;
                        MenuEngine.RemoveControl(threadInfo);
                        threadInfo = null;
                    }
                    else if ( MenuEngine.DEBUGMODE && threadInfo == null && sw == null )
                    {
                        sw = Stopwatch.StartNew();
                        infoOutput = $">Thread Name: {Thread.CurrentThread.Name}<|>Time Between Input: {sw.ElapsedMilliseconds / 1000} Seconds<|>Selected Index: X({currentSelectedIndex_X}) Y({currentSelectedIndex_Y})<";
                        threadInfo = new Label(infoOutput, new Vector2(Console.WindowWidth - infoOutput.Length - 4, 3));
                    }
                    #endregion

                    //lock ( lockObject )
                    //{
                    //    Selected = false;
                    //}

                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if ( keyInfo.Key == NavigationKeys.Debug )
                    {
                        MenuEngine.DEBUGMODE = !MenuEngine.DEBUGMODE;
                    }

                    #region Navigation
                    if ( EnableNavigation )
                    {

                        if ( keyInfo.Key == NavigationKeys.Up )
                        {
                            lock ( lockObject )
                            {
                                MenuEngine.Input.currentSelectedIndex_Y--;
                            }

                        }

                        if ( keyInfo.Key == NavigationKeys.Down )
                        {
                            lock ( lockObject )
                            {
                                MenuEngine.Input.currentSelectedIndex_Y++;
                            }
                        }

                        if ( keyInfo.Key == NavigationKeys.Left )
                        {
                            lock ( lockObject )
                            {
                                MenuEngine.Input.currentSelectedIndex_X--;
                            }
                        }

                        if ( keyInfo.Key == NavigationKeys.Right )
                        {
                            lock ( lockObject )
                            {
                                MenuEngine.Input.currentSelectedIndex_X++;
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
                                OnSelect?.Invoke();
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