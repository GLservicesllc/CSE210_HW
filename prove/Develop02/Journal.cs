using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

     public string GetRatingForDate(string date)
    {
        foreach (Entry entry in _entries)
        {
            if (entry._date == date)
            {
                return entry._rating;
            }
        }
        return "";
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
            outputFile.WriteLine($"{entry._date}~|~{entry._promptText}~|~{entry._entryText}~|~{entry._rating}");
            }
        }    
        Console.WriteLine("Journal saved.");
    }
    
    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("That file doesn't exist.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");

            Entry entry = new Entry(parts[0], parts[1], parts[2], parts[3]);
            _entries.Add(entry);
        }
        Console.WriteLine("Journal loaded.");
    }
}