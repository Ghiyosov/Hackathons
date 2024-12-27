using Domein.Enums;

namespace Domein.Entities;

public class Participant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int TeamId { get; set; }
    public Role Role { get; set; }
    public DateTime JoinedDate { get; set; }

    public Team Team { get; set; }
}