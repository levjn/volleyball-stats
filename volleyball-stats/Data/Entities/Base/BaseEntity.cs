using SQLite;

namespace volleyball_stats.Data.Entities.Base;

public class BaseEntity
{
    [PrimaryKey]
    [Column("id")]
    public Guid Id { get; set; }
}