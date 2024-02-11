using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailLate.Domain.Entities;

public class StopTime : GtfsEntity
{
    [Required]
    [Column("trip_id")]
    public string TripId { get; set; }


    [Required]
    [Column("arrival_time")]
    public DateTime? ArrivalTime { get; set; }
    
    [Required]
    [Column("departure_time")]
    public DateTime? DepartureTime { get; set; }

    [Required]
    [Column("stop_id")]
    public string StopId { get; set; }
    
    [Required]
    [Column("stop_sequence")]
    public uint StopSequence { get; set; }
    
    [Column("stop_headsign")]
    public string StopHeadsign { get; set; }
    
    [Column("pickup_type")]
    public Enums.PickupType? PickupType { get; set; }
    
    [Column("drop_off_type")]
    public Enums.DropOffType? DropOffType { get; set; }
    
    [Column("shape_dist_traveled")]
    public double? ShapeDistTravelled { get; set; }
    
    [Column("timepoint")]
    public Enums.TimePointType TimepointType { get; set; }
}