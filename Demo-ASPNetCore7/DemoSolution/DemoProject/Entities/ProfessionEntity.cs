namespace DemoProject.Entities;

public class ProfessionEntity
{
    public int Id { get; set; }

    public string Title { get; set; }

    public List<PersonEntity> PersonsWithThisProfession { get; set; }
}