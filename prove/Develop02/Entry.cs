public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _rating;


    public Entry(string date, string promptText, string entryText, string rating)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _rating = rating;
    }
    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText} - Rating: {_rating}/10");
        Console.WriteLine(_entryText);
        Console.WriteLine();
    }
}