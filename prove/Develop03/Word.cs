public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }
// This method hides the word by setting the _isHidden flag to true. It is used in the Scripture class to hide random words for memorization purposes.
    public void Hide() => _isHidden = true;
    public void Show() => _isHidden = false;
    public bool IsHidden() => _isHidden;

    public string GetDisplayText()
    {
        if (!_isHidden) return _text;

        string hidden = "";
        foreach (char c in _text)
            hidden += char.IsLetterOrDigit(c) ? '_' : c;
        return hidden;

    }
}