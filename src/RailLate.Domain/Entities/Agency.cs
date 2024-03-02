using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace RailLate.Domain.Entities;

public class Agency : GtfsEntity
{
    [Required]
    [Column("agency_id")]
    public string Id { get; set; }
    
    [Required]
    [Column("agency_name")]
    public string Name { get; set; }

    [Required]
    [Column("agency_url")]
    public string URL { get; set; }
    
    [Required]
    [Column("agency_timezone")]
    public string Timezone { get; set; }
    
    [Column("agency_lang")]
    public string? LanguageCode { get; set; }
    
    [Column("agency_phone")]
    public string? Phone { get; set; }
    
    [Column("agency_fare_url")]
    public string? FareURL { get; set; }
    
    [Column("agency_email")]
    public string? Email { get; set; }
}