using static System.Console;

namespace Hackman
{
    class Game
    {
        private readonly int WindowWidth = 140;
        private readonly int WindowHeight = 30;

        public void Start()
        {
            Title = "HackMan by Nolan Hamel";
            CursorVisible = false;
            
            if(Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetWindowSize(WindowWidth, WindowHeight);
                SetBufferSize(WindowWidth, WindowHeight);
            }
            RunMainMenu();
        }

        private void RunMainMenu()
        {
            Clear();
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
            Clear();
            Tutorial t = new Tutorial();
            t.TutorialHangman();
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