using System;
using System.Threading.Tasks;
using FantasyLEC.Core.Data;
using FantasyLEC.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json;

namespace FantasyLEC.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PointsController : ControllerBase
    {
        private IConfiguration _configuration;
        private ScoringMutiplier _scoring;
        private PlayerService _playerService;
        private TeamService _teamService;

        public PointsController(IConfiguration configuration
        , PlayerService playerService, TeamService teamService)
        {
            _configuration = configuration;
            var json = System.IO.File.ReadAllText($"../{_configuration.GetSection("ConfigFiles")["Scoring"]}");
            _scoring = JsonConvert.DeserializeObject<ScoringMutiplier>(json);

            _playerService = playerService;
            _teamService = teamService;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Test()
        {
            return Ok();
        }
    }
}