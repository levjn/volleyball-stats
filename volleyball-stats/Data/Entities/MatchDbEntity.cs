using SQLite;
using volleyball_stats.Data.Entities.Base;

namespace volleyball_stats.Data.Entities;

public class MatchDbEntity : BaseEntity
{
    [Column("team_a_id")]
    public Guid TeamAId { get; set; }
    
    [Column("team_b_id")]
    public Guid TeamBId { get; set; }

    [Column("playdate")]
    public DateOnly PlayDate { get; set; }
}
