using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailLate.Domain.Entities;

public class FareAttribute : GtfsEntity
{
    [Required]
    [Column("fare_id")]
    public string FareId { get; set; }
    
    [Required]
    [Column("price")]
    public string Price { get; set; }
    
    [Required]
    [Column("currency_type")]
    public string CurrencyType { get; set; }
    
    [Required]
    [Column("payment_method")]
    public Enums.PaymentMethodType PaymentMethod { get; set; }
    
    [Required]
    [Column("transfers")]
    public uint? Transfers { get; set; }
    
    [Column("agency_id")]
    public string AgencyId { get; set; }

    [Column("transfer_duration")]
    public string TransferDuration { get; set; }
}