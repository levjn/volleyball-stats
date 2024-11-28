using SQLite;
using volleyball_stats.Data.Entities.Base;

namespace volleyball_stats.Data.Entities;

public class PlayerDbEntity : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }

    [Column("team")]
    public Guid? TeamId { get; set; } = null;
}