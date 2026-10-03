public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(w => new Word(w))
                    .ToList();
    }
// This hides a specific number of random words in the scripture to help with memorization.
    public void HideRandomWords(int count)
    {
        var visible = _words.Where(w => !w.IsHidden()).ToList();
        count = Math.Min(count, visible.Count);

        for (int i = 0; i < count; i++)
        {
            int index = _random.Next(visible.Count);
            visible[index].Hide();
            visible.RemoveAt(index);
        }
    }

    public bool IsCompletelyHidden() => _words.All(w => w.IsHidden());
    public int GetHiddenCount() => _words.Count(w => w.IsHidden());
    public int GetTotalCount() => _words.Count();
    public string GetDisplayText()
    {
        string text = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()} {text}";
    }
}