using System.Net.Http.Json;
using Demo.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace DemoBlazor.Pages;

public partial class PersonPage : ComponentBase
{
    [Inject] public HttpClient Http { get; set; }
    
    public string Bladiebla { get; set; } = "Hallo daar!";

    public IEnumerable<PersonEntity>? Persons { get; set; }

    void ChangeBladiebla()
    {
        Bladiebla += " iets anders";
    }

    protected override async Task OnInitializedAsync()
    {
        await GetPersons();
    }

    async Task GetPersons()
    {
        Persons = await Http.GetFromJsonAsync<IEnumerable<PersonEntity>>("https://localhost:7046/api/person");
        Console.WriteLine("Aantal persons opgehaald: " + Persons.Count());
    }
}