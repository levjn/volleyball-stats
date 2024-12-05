namespace volleyball_stats.Entities;

public class Match
{
    public Guid Id = Guid.NewGuid();
    public required Team HomeTeam { get; set; }
    public required Team GuestTeam { get; set; }
    public required DateTime PlayDateTime { get; set; }
}