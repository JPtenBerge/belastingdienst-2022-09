using System.ComponentModel.DataAnnotations.Schema;
using DemoProject.Entities;
using DemoProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoProject.Pages;

public class Index : PageModel
{
    public string Message1 { get; set; } = "Bezig met laden van contacten";
    public string Message2 { get; set; } = "Bezig met laden van personen";
    [BindProperty] public PersonEntity NewPerson { get; set; } // model binding

    public IEnumerable<PersonEntity>? Persons { get; set; }
    public IEnumerable<ProfessionEntity>? Professions { get; set; }
    public IEnumerable<SelectListItem>? ProfessionItems { get; set; }
    
    private IPersonRepository _personRepository;
    private IProfessionRepository _professionRepository;

    [BindProperty] public List<int> SelectedPersons { get; set; }
    
    public Index(IPersonRepository personRepository, IProfessionRepository professionRepository)
    {
        _personRepository = personRepository;
        _professionRepository = professionRepository;
    }
    
    public async Task OnGetAsync() // standaardmethode voor de GET OnPut OnPost OnDelete  HTTP
    {
        await GetDataAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Thread.Sleep(2000);
        if (!ModelState.IsValid)
        {
            await GetDataAsync();
            return Page();
        }

        await _personRepository.AddAsync(NewPerson);
        return RedirectToPage();
    }

    private async Task GetDataAsync()
    {
        Persons = await _personRepository.GetAllAsync();
        Professions = await _professionRepository.GetAll();

        ProfessionItems = Professions.Select(x => new SelectListItem
        {
            Value = x.Id.ToString(),
            Text = x.Title
        });
    }
}