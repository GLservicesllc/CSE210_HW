public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "Who was the coolest person that you met today?" ,
        "What was the best part of your day today?" ,
        "In what ways did I see the hand of the Lord today?" ,
        "What emotions did I feel today? What was the strongest emotion felt?" ,
        "What would I change about today if I could?" ,
        "What did I further acomplish today? (Goals/Projects)" ,
        "What was the most important lesson learned today?" ,
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}