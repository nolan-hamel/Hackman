using static System.Console;

namespace Hackman
{
    class Menu
    {
        private string Prompt;
        private string[] MenuOptions;
        private int MenuChoice;
        public Menu(string prompt, string[] options)
        {
            Prompt = prompt;
            MenuOptions = options;
            MenuChoice = 0;
        }
        private void DisplayMenu()
        {
            SetCursorPosition(0, 16);
            for (int i = 0; i < MenuOptions.Length; i++)
            {
                string currentOption = MenuOptions[i];
                string mark = "->";

                if (i == MenuChoice)
                {
                    mark = "->";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.Green;
                }
                else
                {
                    mark = "  ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }
                WriteLine("{0}[ {1,-9}]", mark, currentOption);
            }
            // WriteLine("Q W E R T Y U I O P");
            // WriteLine(" A S D F G H J K L ");
            // WriteLine("  Z X C V B N M    ");
            ResetColor();
        }

        public int Run()
        {
            ConsoleKey key;
            WriteLine(Prompt);
            do
            {
                DisplayMenu();
                do
                {
                    ConsoleKeyInfo keyInfo = ReadKey(true);
                    key = keyInfo.Key;
                } while (KeyAvailable);


                if (key == ConsoleKey.UpArrow)
                {
                    MenuChoice = (MenuOptions.Length + MenuChoice - 1) % MenuOptions.Length;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    MenuChoice = (MenuChoice + 1) % MenuOptions.Length;
                }

            } while (key != ConsoleKey.Enter);
            return MenuChoice;
        }
    }
}