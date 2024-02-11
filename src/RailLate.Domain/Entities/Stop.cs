using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailLate.Domain.Entities;

public class Stop : GtfsEntity
{
    [Required]
    [Column("stop_id")]
    public string Id { get; set; }
    
    [Column("stop_code")]
    public string Code { get; set; }
    
    [Column("stop_name")]
    [Required]
    public string Name { get; set; }
    
    [Column("stop_desc")]
    public string Description { get; set; }
    
    [Required]
    [Column("stop_lat")]
    public double Latitude { get; set; }

    [Required]
    [Column("stop_lon")]
    public double Longitude { get; set; }

    [Column("zone_id")]
    public string Zone { get; set; }
    
    [Column("stop_url")]
    public string Url { get; set; }
    
    [Column("location_type")]
    public Enums.LocationType? LocationType { get; set; }

    [Column("parent_station")]
    public string ParentStation { get; set; }
    
    [Column("stop_timezone")]
    public string Timezone { get; set; }
    
    [Column(" wheelchair_boarding ")]
    public string WheelchairBoarding { get; set; }

    [Column("level_id")]
    public string LevelId { get; set; }
    
    [Column("platform_code")]
    public string PlatformCode { get; set; }
}