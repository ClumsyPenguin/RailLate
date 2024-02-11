using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailLate.Domain.Entities;

public class Shape : GtfsEntity
{
    [Required]
    [Column("shape_id")]
    public string Id { get; set; }
    
    [Required]
    [Column("shape_pt_lat")]
    public double Latitude { get; set; }

    [Required]
    [Column("shape_pt_lon")]
    public double Longitude { get; set; }
    
    [Required]
    [Column("shape_pt_sequence")]
    public uint Sequence { get; set; }
    
    [Column("shape_dist_traveled")]
    public double? DistanceTravelled { get; set; }
}