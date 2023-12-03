using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    public Reference Reference { get; private set; }
    public List<Word> ReferenceWords { get; private set; }
    public List<Word> TextWords { get; private set; }

    public Scripture((string Reference, string Text) scripture)
    {
        Reference = new Reference(scripture.Reference);
        ReferenceWords = scripture.Reference.Split(' ').Select(word => new Word(word)).ToList();
        TextWords = scripture.Text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public string GetVisibleText()
    {
        string visibleReference = string.Join(" ", ReferenceWords.Select(word => word.Text));
        string visibleText = string.Join(" ", TextWords.Select(word => word.IsHidden ? "____" : word.Text));
        return $"{visibleReference}: {visibleText}";
    }
}
