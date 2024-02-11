using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailLate.Domain.Entities;

public class Route : GtfsEntity
{
    [Required]
    [Column("route_id")]
    public string Id { get; set; }

    [Required]
    [Column("agency_id")]
    public string AgencyId { get; set; }

    [Required]
    [Column("route_short_name")]
    public string ShortName { get; set; }
    
    [Required]
    [Column("route_long_name")]
    public string LongName { get; set; }
    
    [Required]
    [Column("route_desc")]
    public string Description { get; set; }
    
    [Required]
    [Column("route_type")]
    public Enums.RouteTypeExtended Type { get; set; }
    
    [Column("route_url")]
    public string Url { get; set; }
    
    [Column("route_color")]
    public int? Color { get; set; }

    [Column("route_text_color")]
    public int? TextColor { get; set; }

}