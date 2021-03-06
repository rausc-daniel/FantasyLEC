using System.Collections.Generic;
using System.IO;
using FantasyLEC.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FantasyLEC.Core
{
    public class FantasyLecDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        
        public FantasyLecDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Player.OnModelCreating(modelBuilder);
            Team.OnModelCreating(modelBuilder);

            SeedDatabase(modelBuilder);
        }

        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            var json = File.ReadAllText($"../{_configuration.GetSection("ConfigFiles")["Teams"]}");
            var teams = JsonConvert.DeserializeObject<List<Team>>(json);

            foreach (var team in teams)
            {
                modelBuilder.Entity<Team>().HasData(new Team
                {
                    Id = team.Id,
                    Code = team.Code,
                    Image = team.Image,
                    Name = team.Name,
                    AveragePoints = 0
                });
                
                foreach (var player in team.Players)
                {   
                    modelBuilder.Entity<Player>().HasData(player);
                }
            }
        }
    }
}