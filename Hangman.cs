using static System.Console;

namespace Hackman
{
    class Hangman
    {
        private Api Request = new Api();
        private string Word = "";
        string Revealed = "";
        private string ChosenLetters = "";
        private string Lives = "♥♥♥♥♥♥";
        private int WordStreak = 0;

        private void DisplayHangman()
        {
            Clear();
            CursorVisible = false;
            WriteLine($"\n  Word Streak: {WordStreak}");
            Write($"  Lives: ");
            ConsoleColor tempColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;
            WriteLine(Lives);
            ForegroundColor = tempColor;
            WriteLine($"  Guessed Letters: {ChosenLetters}");
            WriteLine($"  {Revealed}");
            ResetColor();
        }

        public int Run()
        {
            Word = Request.GetWord();
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
                        Lives = Lives.Remove(Lives.Length-1,1);
                        WrongGuess();
                    }
                    else CorrectGuess();
                }

                if (Word == Revealed)
                {
                    DisplayHangman();
                    WriteLine($" Correct! +3 Lives");
                    WriteLine($" Press any key to continue...");
                    ReadKey(true);
                    WordStreak++;
                    Lives += "♥♥♥";
                    break;
                }

            } while (Lives.Length > 0);
            DisplayHangman();
            if (Word != Revealed)
            {
                WriteLine($" Correct Word: {Word}");
                WriteLine($" Press any key to return to main menu...");
                ReadKey(true);
            }
            return Lives.Length;
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
        }

        public void CorrectGuess()
        {
            int waitTime = 500;
            ForegroundColor = ConsoleColor.Green;
            DisplayHangman();
            Thread.Sleep(waitTime);
        }
    }
}
