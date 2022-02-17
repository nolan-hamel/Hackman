using static System.Console;

namespace Hackman
{
    class Tutorial
    {
        string Word = "hackman";
        string Revealed = "";
        string ChosenLetters = "";
        string Lives = "∞";
        int WordStreak = 0;
        public void RunTutorial()
        {
            Revealed = new string ('_', Word.Length);


        }
    }
}
