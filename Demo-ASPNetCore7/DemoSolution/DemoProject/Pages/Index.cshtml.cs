using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoProject.Pages;

public class Index : PageModel
{
    [BindProperty] public PersonEntity NewPerson { get; set; } // model binding

    public static List<PersonEntity>? Persons { get; set; } = new()
    {
        new()
        {
            Id = 4,
            Name = "Elon Musk",
            Age = 51
        },
        new()
        {
            Id = 8,
            Name = "Jeffrey Bezos",
            Age = 58
        },
        new()
        {
            Id = 15,
            Name = "Billy Gates",
            Age = 67
        }
    };

    public void OnGet() // standaardmethode voor de GET OnPut OnPost OnDelete  HTTP
    {
        Console.WriteLine("On GET");
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Persons.Add(NewPerson);
        // redirect naar GET
        return RedirectToPage();
    }
}