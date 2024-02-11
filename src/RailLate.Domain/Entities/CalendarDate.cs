using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailLate.Domain.Entities;

public class CalendarDate : GtfsEntity
{
    [Required]
    [Column("service_id")]
    public string ServiceId { get; set; }
    
    [Required]
    [Column("date")]
    public DateTime Date { get; set; }
    
}