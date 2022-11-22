using System.ComponentModel.DataAnnotations.Schema;
using DemoProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoProject.Pages;

public class Index : PageModel
{
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