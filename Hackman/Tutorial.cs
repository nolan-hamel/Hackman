using static System.Console;

namespace Hackman
{
    class Tutorial
    {
        private string Word = "hackman";
        string Revealed = "";
        private string ChosenLetters = "";

        public void TutorialHangman()
        {
            WriteLine($"  Welcome to Hackman! A Hangman style game created by Nolan Hamel.");
            WriteLine($"  In this tutorial you will do a test run of a round to learn the basics of HackMan.");
            WriteLine($"\n  Press any key to continue...");
            ReadKey(true);
            Clear();
            WriteLine($"  Press a key and see what happens...");
            RunTutorialHangman();
            Clear();
            WriteLine($"  Thanks for trying out the tutorial! Now you're ready for a real game :) Good Luck!");
            WriteLine($"\n  Press any key to return to main menu...");
            ReadKey(true);

        }
        private void DisplayHangman()
        {
            SetCursorPosition(0, 1);
            CursorVisible = false;
            WriteLine($"\n  Score: 0");
            WriteLine($"  Word Streak: 0");
            Write($"  Lives: ");
            ConsoleColor tempColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;
            WriteLine("∞");
            ForegroundColor = tempColor;
            WriteLine($"  Guessed Letters: {ChosenLetters}");
            WriteLine($"  {Revealed}");
            ResetColor();
        }

        public void RunTutorialHangman()
        {
            Revealed = new string('_', Word.Length);
            ChosenLetters = "";
            do
            {
                bool letterInWord = false;
                DisplayHangman();
                // get user key press
                string letterStr;
                do
                {
                    ConsoleKeyInfo keyInfo = ReadKey(true);
                    letterStr = keyInfo.Key.ToString();
                } while (KeyAvailable);

                char letter = Char.ToLower(letterStr[0]);
                // if user chosen key is valid check where it is in the word
                if (!ChosenLetters.Contains(letter) && letterStr.Length == 1)
                {
                    ChosenLetters += letter;
                    // fill in matching letters
                    for (int i = 0; i < Word.Length; i++)
                    {
                        if (letter == Word[i])
                        {
                            letterInWord = true;
                            Revealed = Revealed.Remove(i, 1).Insert(i, Word[i].ToString());
                        }
                    }

                    // if letter choice is bad then decrement Lives 
                    if (!letterInWord)
                    {
                        WrongGuess();
                    }
                    else CorrectGuess();
                }

                if (Word == Revealed)
                {
                    DisplayHangman();
                    WriteLine($"  Correct!");
                    WriteLine($"  Press any key to continue...");
                    ReadKey(true);
                    break;
                }

            } while (Word != Revealed);
            DisplayHangman();
        }

        public void WrongGuess()
        {
            int waitTime = 50;
            ForegroundColor = ConsoleColor.Red;
            DisplayHangman();
            Thread.Sleep(waitTime);
            DisplayHangman();
            Thread.Sleep(waitTime);
            ForegroundColor = ConsoleColor.Red;
            DisplayHangman();
            Thread.Sleep(waitTime);
            SetCursorPosition(0, 0);
            WriteLine($"                                                                                        ");
            SetCursorPosition(0, 0);
            WriteLine($"  Red flashing means you chose a wrong letter. Try again! :)");

        }

        public void CorrectGuess()
        {
            int waitTime = 500;
            ForegroundColor = ConsoleColor.Green;
            DisplayHangman();
            Thread.Sleep(waitTime);
            SetCursorPosition(0, 0);
            WriteLine($"                                                                                        ");
            SetCursorPosition(0, 0);
            WriteLine($"  Good job! Green means you chose a correct letter :)");
        }
    }
}
