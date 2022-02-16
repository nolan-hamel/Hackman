using static System.Console;

namespace Hackman
{
    class Game
    {
        private readonly int WindowWidth = LargestWindowWidth / 2;
        private readonly int WindowHeight = LargestWindowHeight / 2;

        public void Start()
        {
            Title = "HackMan by Nolan Hamel";
            CursorVisible = false;
            
            SetWindowSize(WindowWidth, WindowHeight);
            SetBufferSize(WindowWidth, WindowHeight);
            RunMainMenu();
        }

        private void RunMainMenu()
        {
            string prompt = @"
                

                                     ██╗  ██╗ █████╗  ██████╗██╗  ██╗███╗   ███╗ █████╗ ███╗   ██╗
                                     ██║  ██║██╔══██╗██╔════╝██║ ██╔╝████╗ ████║██╔══██╗████╗  ██║
                                     ███████║███████║██║     █████╔╝ ██╔████╔██║███████║██╔██╗ ██║
                                     ██╔══██║██╔══██║██║     ██╔═██╗ ██║╚██╔╝██║██╔══██║██║╚██╗██║
                                     ██║  ██║██║  ██║╚██████╗██║  ██╗██║ ╚═╝ ██║██║  ██║██║ ╚████║
                                     ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝                                    
       

 Welcome to Hackman! A Hangman style game created by Nolan Hamel.
 Choose an option using the UP and DOWN arrow keys and press ENTER to select.
 Change window scale with ctrl + scroll.
";
            string[] options = { "Play", "Tutorial", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int chosenOption = mainMenu.Run();

            switch (chosenOption)
            {
                case 0:
                    StartHangman();
                    break;
                case 1:
                    DisplayTutorial();
                    break;
                case 2:
                    ExitGame();
                    break;

            }
        }

        private void StartHangman()
        {
            Hangman hangman = new Hangman();
            int lives;
            do
            {
                lives = hangman.Run();
            } while (lives > 0);
            RunMainMenu();
        }

        private void DisplayTutorial()
        {
            for(int i = 1; i<2; i++)
            {
                Clear();
                string fileString = @"C:\Users\nolan\Desktop\Sophia\personal_projects\Hackman\tutorial\page";
                fileString += i.ToString() + ".txt";
                string[] fileText = File.ReadAllLines(fileString);
                for (int j = 0; j < fileText.Length; j++) WriteLine(fileText[j]);
                WriteLine("\n\t\t\t\tPress any key to continue...");
                ReadKey(true);
            }

            RunMainMenu();
        }

        private void ExitGame()
        {
            //WriteLine("Press any key to exit...");
            //ReadKey(true);
            Environment.Exit(0);
        }

    }
}