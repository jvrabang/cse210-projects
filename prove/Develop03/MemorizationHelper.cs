using System;

class MemorizationHelper
{
    private readonly Scripture scripture;
    private Random random = new Random();

    public MemorizationHelper(Scripture scripture)
    {
        this.scripture = scripture;
    }

    public bool AllWordsHidden => scripture.TextWords.All(word => word.IsHidden);

    public void HideRandomWords()
    {
        var visibleWords = scripture.TextWords.Where(word => !word.IsHidden).ToList();

        if (visibleWords.Any())
        {
            var wordToHide = visibleWords[random.Next(visibleWords.Count)];
            wordToHide.Hide();
        }
    }

    public string GetVisibleScripture()
    {
        if (AllWordsHidden)
        {
            return "Congratulations! You have successfully memorized the scripture!";
        }
        else
        {
            return scripture.GetVisibleText();
        }
    }
}
