using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailLate.Domain.Entities;

public class Trip : GtfsEntity
{
    [Required]
    [Column("trip_id")]
    public string Id { get; set; }
    
    [Required]
    [Column("route_id")]
    public string RouteId { get; set; }
    
    [Required]
    [Column("service_id")]
    public string ServiceId { get; set; }
    
    [Column("trip_headsign")]
    public string Headsign { get; set; }

    [Column("trip_short_name")]
    public string ShortName { get; set; }
    
    [Column("direction_id")]
    public Enums.DirectionType? Direction { get; set; }

    [Column("block_id")]
    public string BlockId { get; set; }
    
    [Column("shape_id")]
    public string ShapeId { get; set; }
    
    [Column("wheelchair_accessible")]
    public Enums.WheelchairAccessibilityType? AccessibilityType { get; set; }
}