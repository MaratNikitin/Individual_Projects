using EfCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Data;

public class FootballLeagueDbContext : DbContext
{
    public DbSet<Team> Teams { get; set; }
    public DbSet<Coach> Coaches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog = FootballLeague_EfCore; Encrypt=False;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    TeamId = 1,
                    TeamName = "Tivoli Gardens FC",
                    CreatedDate = DateTimeOffset.UtcNow.DateTime,
                },

                new Team
                {
                    TeamId = 2,
                    TeamName = "Waterhouse FC",
                    CreatedDate = DateTimeOffset.UtcNow.DateTime,
                },

                new Team
                {
                    TeamId = 3,
                    TeamName = "Humble Lions FC",
                    CreatedDate = DateTimeOffset.UtcNow.DateTime,
                }
            );
    }

}
