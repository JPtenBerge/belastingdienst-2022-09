using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace DemoBlazor.Pages;

public partial class Persons : ComponentBase
{
    [Inject] public HttpClient Http { get; set; }
    
    public string Bladiebla { get; set; } = "Hallo daar!";

    void ChangeBladiebla()
    {
        Bladiebla += " iets anders";
    }

    async Task GetPersons()
    {
        var persons = await Http.GetFromJsonAsync<IEnumerable<object>>("https://localhost:7046/api/person");
        Console.WriteLine("Aantal persons opgehaald: " + persons.Count());
    }
}