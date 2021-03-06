namespace FantasyLEC.Core.Data
{
    public class IndividualMultiplier
    {
        public double Kills { get; set; }
        public double Type { get; set; }
        public double Assists { get; set; }
        public double CreepScore { get; set; }
        public double FirstBloodBonus { get; set; }
        public double TripleKills { get; set; }
        public double QuadraKills { get; set; }
        public double PentaKills { get; set; }
    }

    public class TeamMultiplier
    {
        public double Turrets { get; set; }
        public double Dragons { get; set; }
        public double ElderDragons { get; set; }
        public double Barons { get; set; }
        public double Wins { get; set; }
        public double FirstTurretBonus { get; set; }
        public double WinLessThanThirtyMinutes { get; set; }
    }

    public class ScoringMutiplier
    {
        public IndividualMultiplier IndividualMultiplier { get; set; }
        public TeamMultiplier TeamMultiplier { get; set; }
    }
}