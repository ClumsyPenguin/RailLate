using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailLate.Domain.Entities;

public class Frequency : GtfsEntity
{
    [Required]
    [Column("trip_id")]
    public string TripId { get; set; }
    
    [Required]
    [Column("start_time")]
    public string StartTime { get; set; }

    [Required]
    [Column("end_time")]
    public string EndTime { get; set; }
    
    [Required]
    [Column("headway_secs")]
    public string HeadwaySecs { get; set; }
    
    [Column("exact_times")]
    public bool? ExactTimes { get; set; }
}