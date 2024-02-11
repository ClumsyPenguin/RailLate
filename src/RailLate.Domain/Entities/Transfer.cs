using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailLate.Domain.Entities;

public class Transfer : GtfsEntity
{
    [Required]
    [Column("from_stop_id")]
    public string FromStopId { get; set; }
    
    [Required]
    [Column("to_stop_id")]
    public string ToStopId { get; set; }
    
    [Required]
    [Column("transfer_type")]
    public Enums.TransferType TransferType { get; set; }
    
    [Column("min_transfer_time")]
    public string MinimumTransferTime { get; set; }
}