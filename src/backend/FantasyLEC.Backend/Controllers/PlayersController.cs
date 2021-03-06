using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyLEC.Core.Models;
using FantasyLEC.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FantasyLEC.Backend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly PlayerService _playerService;

        public PlayersController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<ICollection<Player>> GetPlayers([FromQuery(Name = "role")] Role? role, [FromQuery(Name = "team")] string teamCode)
        {
            if (role is not null && teamCode is null)
            {
                return await _playerService.GetPlayersAsync(role.Value);
            }

            if (teamCode is not null && role is null)
            {
                return await _playerService.GetPlayersAsync(teamCode);
            }

            if (teamCode is not null)
            {
                return await _playerService.GetPlayersAsync(teamCode, role.Value);
            }

            return await _playerService.GetPlayersAsync();
        }
    }
}