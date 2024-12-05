namespace volleyball_stats.Entities;

public class Player
{
    public Guid Id = Guid.NewGuid();
    public required string Name { get; set; }
    public Team Team { get; set; }
}