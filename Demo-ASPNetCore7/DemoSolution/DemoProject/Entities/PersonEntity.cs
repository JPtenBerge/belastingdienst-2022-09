using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoProject.Entities;

public class PersonEntity
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Vul dit in aub")]
    [MaxLength(50, ErrorMessage = "Max 50 karakters graag")]
    public string Name { get; set; }

    [Required]
    [Range(0, 130)]
    public int? Age { get; set; } // 32 bits = 2^32 = 2.147.xxx.xxx

    [Required]
    public int? ProfessionId { get; set; }

    // [ForeignKey("ProfessionId")]
    public ProfessionEntity? Profession { get; set; }
}
