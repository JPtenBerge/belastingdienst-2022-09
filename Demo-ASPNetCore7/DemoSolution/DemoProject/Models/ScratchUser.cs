using Microsoft.AspNetCore.Identity;

namespace DemoProject.Models;

public class ScratchUser : IdentityUser
{
    public string FavorieteSnack { get; set; }

    public int AantalFrikandellen { get; set; }
}
