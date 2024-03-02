using System.ComponentModel.DataAnnotations;

namespace RailLate.Domain.Entities;

public class GtfsEntity
{
    [Key]
    public Guid Id { get; set; }
    
    public string? Tag { get; set; }
}