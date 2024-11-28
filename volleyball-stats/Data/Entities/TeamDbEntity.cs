using SQLite;
using volleyball_stats.Data.Entities.Base;

namespace volleyball_stats.Data.Entities;

public class TeamDbEntity : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }
}