using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace FantasyLEC.Core.Models
{
    public class Team
    {
        public TeamId Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Image { get; set; }
        public double AveragePoints { get; set; }
        
        [JsonIgnore]
        public ICollection<Player> Players { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Team>();

            entity.HasKey(t => t.Id);

            entity.Property(t => t.Code).HasMaxLength(3);
        }
    }

    public enum TeamId
    {
        Undefined,
        G2,
        Fnatic,
        Rogue,
        MadLions,
        Schalke04,
        Astralis,
        Excel,
        Misfits,
        SkGaming,
        Vitality
    }
}