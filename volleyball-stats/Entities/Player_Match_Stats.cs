namespace volleyball_stats.Entities;

public class Player_Match_Stats
{
    public Guid Id = Guid.NewGuid();
    public required Player Player { get; set; }
    public required Match match { get; set; }
    public required int Points { get; set; }
    public required int erorrs { get; set; }
}