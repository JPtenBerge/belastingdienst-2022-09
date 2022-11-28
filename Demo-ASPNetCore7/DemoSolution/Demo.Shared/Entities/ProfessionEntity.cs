using System.Text.Json.Serialization;

namespace Demo.Shared.Entities;

public class ProfessionEntity
{
	public int Id { get; set; }

	public string Title { get; set; }

	[JsonIgnore]
	public List<PersonEntity> PersonsWithThisProfession { get; set; }
}