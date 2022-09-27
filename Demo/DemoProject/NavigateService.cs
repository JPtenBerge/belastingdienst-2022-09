namespace DemoProject;

public interface INavigateService
{
    void Next(List<NavigableItem> navigableItems);
}

public class NavigateService : INavigateService
{
    public void Next(List<NavigableItem> navigableItems)
    {
        Console.WriteLine("echte next");
    }
}