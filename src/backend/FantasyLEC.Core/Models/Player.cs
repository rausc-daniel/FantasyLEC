using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace FantasyLEC.Core.Models
{
    public class Player
    {
        public int Id { get; set; }
        public TeamId TeamId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SummonerName { get; set; }
        public string Image { get; set; }
        public double AveragePoints { get; set; }
        public string CountryCode { get; set; }
        public Role Role { get; set; }

        [JsonIgnore]
        public Team Team { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Player>();

            entity.HasKey(p => p.Id);

            entity.HasIndex(p => p.SummonerName).IsUnique();

            entity
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId);
        }
    }

    public enum Role
    {
        Top,
        Jungle,
        Mid,
        Adc,
        Support
    }
}