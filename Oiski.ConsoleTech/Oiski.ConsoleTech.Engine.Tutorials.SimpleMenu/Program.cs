using System;
using System.IO;
using System.Reflection;
using Oiski.ConsoleTech.Engine;
using Oiski.ConsoleTech.Engine.Controls;

namespace Oiski.ConsoleTech.Engine.Tutorials.SimpleMenu
{
    class Program
    {
        static readonly Menu main = new Menu();
        static readonly Menu textMenu = new Menu();
        static void Main(string[] args)
        {
            OiskiEngine.Input.SetNavigation("Horizontal", false);
            OiskiEngine.Run();
            CreateMainMenu();
            CreateTextMenu();
        }

        public static void CreateMainMenu()
        {
            #region Initialize Controls

            #region Header
            Label header = new Label("Oiski's Text Writer", _attachToEngine: false);
            header.Position = new Vector2(Console.WindowWidth / 2 - header.Text.Length, 0);
            #endregion

            #region Next Menu Button
            Option nextMenu_button = new Option("Write To File", new Vector2(25, header.Position.y + 6), _attachToEngine: false)
            {
                SelectedIndex = new Vector2(0, 0)
            };
            nextMenu_button.BorderStyle(BorderArea.Horizontal, '~');

            nextMenu_button.OnSelect += (s) => { main.Show(false); textMenu.Show(true); };
            #endregion

            #region Exit Application Button
            Option exit_button = new Option("Exit", new Vector2(nextMenu_button.Position.x, nextMenu_button.Position.y + 3), _attachToEngine: false)
            {
                SelectedIndex = new Vector2(0, 1)
            };

            exit_button.OnSelect += (s) => Environment.Exit(0);
            #endregion
            #endregion

            #region Add Controls to the Main Menu
            main.Controls.AddControl(header);
            main.Controls.AddControl(nextMenu_button);
            main.Controls.AddControl(exit_button);
            main.Show(true);
            #endregion
        }

        public static void CreateTextMenu()
        {
            #region Initialize Controls

            #region Header
            Label header = new Label("Oiski's Text Writer", _attachToEngine: false);
            header.Position = new Vector2(Console.WindowWidth / 2 - header.Text.Length, 0);
            #endregion

            #region Write To File Text Field
            TextField toWriteToFile = new TextField("Type Somehting in me!", new Vector2(25, header.Position.y + 6), _attachToEngine: false)
            {
                SelectedIndex = new Vector2(0, 0),
                ResetAfterFirstWrite = true,
                EraseTextOnSelect = true
            };
            toWriteToFile.OnSelect += WriteToFile;
            toWriteToFile.BorderStyle(BorderArea.Horizontal, '~');
            #endregion

            #region Exit Application Button
            Option back_button = new Option("Back", new Vector2(toWriteToFile.Position.x, toWriteToFile.Position.y + 3), _attachToEngine: false)
            {
                SelectedIndex = new Vector2(0, 1)
            };

            back_button.OnSelect += (s) => { textMenu.Show(false); main.Show(true); };
            #endregion
            #endregion

            #region Add Controls to the Main Menu
            textMenu.Controls.AddControl(header);
            textMenu.Controls.AddControl(toWriteToFile);
            textMenu.Controls.AddControl(back_button);
            textMenu.Show(false);
            #endregion
        }

        public static void WriteToFile(SelectableControl _control)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            using ( StreamWriter writer = File.CreateText($"{path}\\SimpleMenu.txt") )
            {
                writer.WriteLine(_control.Text);
            }
        }
    }
}
