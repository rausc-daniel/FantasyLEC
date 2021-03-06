using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyLEC.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FantasyLEC.Core.Services
{
    public class PlayerService
    {
        private readonly FantasyLecDbContext _dbContext;

        public PlayerService(FantasyLecDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<Player>> GetPlayersAsync(Role role)
        {
            return await _dbContext.Players.Where(p => p.Role == role).ToListAsync();
        }

        public async Task<ICollection<Player>> GetPlayersAsync(string teamCode)
        {
            return await _dbContext.Players
                .Where(p => p.Team.Code.ToLower() == teamCode.ToLower())
                .OrderBy(p => p.Role)
                .ToListAsync();
        }

        public async Task<ICollection<Player>> GetPlayersAsync(string teamCode, Role role)
        {
            return await _dbContext.Players
                .Where(p => p.Team.Code.ToLower() == teamCode.ToLower() && p.Role == role)
                .OrderBy(p => p.Role)
                .ToListAsync();
        }

        public async Task<ICollection<Player>> GetPlayersAsync()
        {
            return await _dbContext.Players.ToListAsync();
        }
    }
}