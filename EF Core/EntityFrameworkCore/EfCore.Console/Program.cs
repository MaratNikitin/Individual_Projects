using EfCore.Data;
using Microsoft.EntityFrameworkCore;

using var context = new FootballLeagueDbContext();

//await GetAllTeamsAsync();
//await GetOneTeamAsync();
await GetAllTeamsFilteredAsync();

async Task GetAllTeamsFilteredAsync()
{
    var teamsFiltered = await context.Teams.Where(x => x.TeamName == "Tivoli Gardens FC").ToListAsync();
    Console.WriteLine("Filtered Teams:");

    foreach (var team in teamsFiltered)
    {
        Console.WriteLine(team.TeamName);
    }
}


async Task GetAllTeamsAsync()
{
    var teams = await context.Teams.ToListAsync();

    foreach (var team in teams)
    {
        Console.WriteLine(team.TeamName);
    }
}

async Task GetOneTeamAsync()
{
    var teamTwo = await context.Teams.FirstOrDefaultAsync(x => x.TeamName.Contains("house"));

    // Use FindAsync method to search by the primary key:
    var teamThree = await context.Teams.FindAsync(3);

    Console.WriteLine($"Team 2 found: {teamTwo.TeamName}");
    Console.WriteLine($"Team 3 found: {teamThree.TeamName}");
}



