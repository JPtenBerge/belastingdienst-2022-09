using Microsoft.AspNetCore.Identity;

namespace Demo.Shared.Entities;

public class ScratchUser : IdentityUser
{
    public string FavorieteSnack { get; set; }

    public int AantalFrikandellen { get; set; }
}
