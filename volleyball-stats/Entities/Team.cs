namespace volleyball_stats.Entities;

public class Team
{
    public Guid Id = Guid.NewGuid();
    public required string Name { get; set; }
}