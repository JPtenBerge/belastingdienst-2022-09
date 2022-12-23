using System.ComponentModel.DataAnnotations;

namespace Hangman.Shared;

public class PlayerEntity
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }

    public List<GameEntity> Games { get; set; }
}