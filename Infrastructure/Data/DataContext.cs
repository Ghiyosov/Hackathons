using Domein.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Hackathon> Hackathons { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Participant> Participants { get; set; }
}