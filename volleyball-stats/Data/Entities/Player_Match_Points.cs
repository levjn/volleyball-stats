using SQLite;
using volleyball_stats.Data.Entities.Base;

namespace volleyball_stats.Data.Entities;

public class Player_Match_Points : BaseEntity
{
    [Column("player_id")]
    public Guid PlayerId { get; set; }
    
    [Column("match_id")]
    public Guid MatchId { get; set; }
    
    [Column("points")]
    public int Points { get; set; } = 0;

    [Column("faults")]
    public int Faults { get; set; } = 0;
}
