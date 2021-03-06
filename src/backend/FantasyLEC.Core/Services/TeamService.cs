using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyLEC.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FantasyLEC.Core.Services
{
    public class TeamService
    {
        private FantasyLecDbContext _dbContext;

        public TeamService(FantasyLecDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<ICollection<Team>> GetTeamsAsync()
        {
            return await _dbContext.Teams.ToListAsync();
        }

        public async Task<Team> GetTeamAsync(string code)
        {
            var team = await _dbContext.Teams.FirstOrDefaultAsync(t => t.Code.ToLower() == code.ToLower());
            team.Players = await _dbContext.Players.Where(p => p.TeamId == team.Id).ToListAsync();
            return team;
        }
    }
}