namespace volleyball_stats.Entities;

public class Match
{
    public Guid Id = Guid.NewGuid();
    public required Team TeamA { get; set; }
    public required Team TeamB { get; set; }
    public required DateOnly PlayDate { get; set; }
}