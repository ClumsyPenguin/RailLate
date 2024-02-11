using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailLate.Domain.Entities;

public class FareRule : GtfsEntity
{
    [Required]
    [Column("fare_id")]
    public string FareId { get; set; }

    [Column("route_id")]
    public string RouteId { get; set; }
    
    [Column("origin_id")]
    public string OriginId { get; set; }
    
    [Column("destination_id")]
    public string DestinationId { get; set; }
    
    [Column("contains_id")]
    public string ContainsId { get; set; }
}