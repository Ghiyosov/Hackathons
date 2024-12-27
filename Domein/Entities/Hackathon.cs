namespace Domein.Entities;

public class Hackathon
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Theme { get; set; }

    public List<Team> Teams { get; set; }
}