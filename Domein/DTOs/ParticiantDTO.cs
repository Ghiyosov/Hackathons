using Domein.Enums;

namespace Domein.DTOs;

public class ParticiantDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int TeamId { get; set; }
    public Role Role { get; set; }
    public DateTime JoinedDate { get; set; }
}