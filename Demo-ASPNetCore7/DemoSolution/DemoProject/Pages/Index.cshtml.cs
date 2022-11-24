using System.ComponentModel.DataAnnotations.Schema;
using DemoProject.Entities;
using DemoProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoProject.Pages;

public class Index : PageModel
{
    public string Message1 { get; set; } = "Bezig met laden van contacten";
    public string Message2 { get; set; } = "Bezig met laden van personen";
    [BindProperty] public PersonEntity NewPerson { get; set; } // model binding

    public IEnumerable<PersonEntity>? Persons { get; set; }
    private IPersonRepository _personRepository;

    [BindProperty] public List<int> SelectedPersons { get; set; }
    
    public Index(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }
    
    public async Task OnGetAsync() // standaardmethode voor de GET OnPut OnPost OnDelete  HTTP
    {
        Persons = await _personRepository.GetAllAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Persons = await _personRepository.GetAllAsync();
            return Page();
        }

        await _personRepository.AddAsync(NewPerson);
        return RedirectToPage();
    }
}