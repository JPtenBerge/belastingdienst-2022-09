namespace DemoProject;

public class Autocompleter
{
    public List<string> Suggestions { get; set; }
    public string Query { get; set; }
    public List<string> Data { get; set; }

    public void Autocomplete()
    {
        Suggestions = new List<string>();
        if (string.IsNullOrWhiteSpace(Query))
        {
            return;
        }

        foreach (var item in Data)
        {
            if (item.ToLower().Contains(Query.ToLower()))
            {
                Suggestions.Add(item);
            }
        }
    }
}