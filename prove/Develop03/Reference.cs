using System;
using System.Linq;

class Reference
{
    public string FullReference { get; private set; }
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int? StartVerse { get; private set; }
    public int? EndVerse { get; private set; }

    public Reference(string fullReference)
    {
        FullReference = fullReference;
        ParseReference();
    }

    private void ParseReference()
    {
        string[] parts = FullReference.Split(' ');

        Book = parts[0];

        string chapterVersePart = parts[1];

        string[] chapterVerseParts = chapterVersePart.Split(':');
        Chapter = int.Parse(chapterVerseParts[0]);

        if (chapterVerseParts.Length > 1)
        {
            string[] verseParts = chapterVerseParts[1].Split('-');

            StartVerse = int.Parse(verseParts[0]);

            if (verseParts.Length > 1)
            {
                EndVerse = int.Parse(verseParts[1]);
            }
        }
    }

    public string GetFormattedReference()
    {
        if (StartVerse.HasValue && EndVerse.HasValue)
        {
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        }
        else if (StartVerse.HasValue)
        {
            return $"{Book} {Chapter}:{StartVerse}";
        }
        else
        {
            return $"{Book} {Chapter}";
        }
    }
}
