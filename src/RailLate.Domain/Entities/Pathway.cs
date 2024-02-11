using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailLate.Domain.Entities;

public class Pathway : GtfsEntity
{
    [Required]
    [Column("pathway_id")]
    public string Id { get; set; }
    
    [Required]
    [Column("from_stop_id")]
    public string FromStopId { get; set; }
    
    [Required]
    [Column("to_stop_id")]
    public string ToStopId { get; set; }
    
    [Required]
    [Column("pathway_mode")]
    public Enums.PathwayMode PathwayMode { get; set; }

    [Required]
    [Column("is_bidirectional")]
    public Enums.IsBidirectional IsBidirectional { get; set; }
    
    [Column("length")]
    public double? Length { get; set; }
    
    [Column("traversal_time")]
    public int? TraversalTime { get; set; }
    
    [Column("stair_count")]
    public int? StairCount { get; set; }
    
    [Column("max_slope")]
    public double? MaxSlope { get; set; }

    [Column("min_width")]
    public double? MinWidth { get; set; }
    
    [Column("signposted_as")]
    public string SignpostedAs { get; set; }
    
    [Column("reversed_signposted_as")]
    public string ReversedSignpostedAs { get; set; }
}