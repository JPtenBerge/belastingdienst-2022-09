namespace DemoProject;

public class Autocompleter
{
    public List<NavigableItem> Suggestions { get; set; }
    public string Query { get; set; }
    public List<string> Data { get; set; }

    // hard gekoppeld?
    // interface
    // type van object
    private INavigateService _navigateService;
    
    // constructor injection
    // dependency injection
    // sommige mensen vinden dat geen code specifiek voor testen in je code mag hebben
    public Autocompleter() // production
    {
        _navigateService = new NavigateService();
    }
    public Autocompleter(INavigateService navigateService) // test
    {
        _navigateService = navigateService;
    }

    public void Autocomplete()
    {
        Suggestions = new List<NavigableItem>();
        if (string.IsNullOrWhiteSpace(Query))
        {
            return;
        }

        foreach (var item in Data)
        {
            if (item.ToLower().Contains(Query.ToLower()))
            {
                Suggestions.Add(new NavigableItem { Item = item });
            }
        }
    }

    public void NextSuggestion()
    {
        _navigateService.Next(Suggestions);
    }
    
}