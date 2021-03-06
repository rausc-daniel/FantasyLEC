using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyLEC.Core.Models;
using FantasyLEC.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FantasyLEC.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private TeamService _teamService;

        public TeamsController(TeamService teamService)
        {
            _teamService = teamService;
        }
        
        [HttpGet]
        public async Task<ICollection<Team>> GetTeams()
        {
            return await _teamService.GetTeamsAsync();
        }

        [HttpGet("{code}")]
        public async Task<Team> GetTeam(string code)
        {
            return await _teamService.GetTeamAsync(code);
        }
    }
}