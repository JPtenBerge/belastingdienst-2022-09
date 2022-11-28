using Demo.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoProject.Pages;

public class Auth : PageModel
{
    private readonly UserManager<ScratchUser> _userManager;
    private readonly SignInManager<ScratchUser> _signInManager;

    public Auth(UserManager<ScratchUser> userManager, SignInManager<ScratchUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    public string Status { get; set; }
    
    public async Task OnGetAsync(string action)
    {
        switch (action)
        {
            case "register": await Register(); break;
            case "login": await LogIn(); break;
            case "logout": await LogOut(); break;
            case "do-nothing": await DoNothing(); break;
        }
    }

    async Task Register()
    {
        var jp = new ScratchUser
        {
            UserName = "JP",
            FavorieteSnack = "Mexicano",
            AantalFrikandellen = 1,
            Email = "jp@Jp.nl"
        };
        var result = await _userManager.CreateAsync(jp, "Top$ecreT123");
        if (result.Succeeded)
        {
            Status = "Geregistreerd!";
        }
        else
        {
            Status = string.Join(", ", result.Errors.Select(x => x.Description));
        }
    }

    async Task LogIn()
    {
        var result = await _signInManager.PasswordSignInAsync("JP", "Top$ecreT123", true, false);
        if (result.Succeeded)
        {
            Status = "Ingelogd!";
        }
        else
        {
            Status = $"Kon niet inloggen {result.IsLockedOut}|{result.IsNotAllowed}|{result.RequiresTwoFactor}";
        }
    }

    async Task LogOut()
    {
        await _signInManager.SignOutAsync();
        Status = "Uitgelogd!";
    }

    async Task DoNothing()
    {
        Console.WriteLine("Ik doe ff helemaal niks. Laterrrrrr");
    }
}