namespace Hangman.Services;

public class WordService : IWordService
{
    public string GetRandomWord()
    {
        var words = new string[]
        {
            "MINIMUMTEMPERATUREN",
            "MONITORSTANDAARD",
            "COMPUTERMUIS",
            "GALGJE"
        };

        var rand = new Random();
        return words[rand.Next(0, 4)];
    }
}