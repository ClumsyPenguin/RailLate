using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailLate.Domain.Entities;

public class Level : GtfsEntity
{
    [Required]
    [Column("level_id")]
    public string Id { get; set; }
    
    [Required]
    [Column("level_index")]
    public double Index { get; set; }
    
    [Column("level_name")]
    public string Name { get; set; }
}