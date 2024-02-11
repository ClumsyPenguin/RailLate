using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailLate.Domain.Entities;

public class Calendar : GtfsEntity
{
    [Required]
    [Column("service_id")]
    public string ServiceId { get; set; }
    
    public byte Mask { get; set; }
    
    [Required]
    [Column("monday")]
    public bool Monday
    {
      get => this[DayOfWeek.Monday];
      set => this[DayOfWeek.Monday] = value;
    }
    
    [Required]
    [Column("tuesday")]
    public bool Tuesday
    {
      get => this[DayOfWeek.Tuesday];
      set => this[DayOfWeek.Tuesday] = value;
    }
    
    [Required]
    [Column("wednesday")]
    public bool Wednesday
    {
      get => this[DayOfWeek.Wednesday];
      set => this[DayOfWeek.Wednesday] = value;
    }
    
    [Required]
    [Column("thursday")]
    public bool Thursday
    {
      get => this[DayOfWeek.Thursday];
      set => this[DayOfWeek.Thursday] = value;
    }
    
    [Required]
    [Column("friday")]
    public bool Friday
    {
      get => this[DayOfWeek.Friday];
      set => this[DayOfWeek.Friday] = value;
    }
    
    [Required]
    [Column("saturday")]
    public bool Saturday
    {
      get => this[DayOfWeek.Saturday];
      set => this[DayOfWeek.Saturday] = value;
    }
    
    [Required]
    [Column("sunday")]
    public bool Sunday
    {
      get => this[DayOfWeek.Sunday];
      set => this[DayOfWeek.Sunday] = value;
    }
    
    [Required]
    [Column("start_date")]
    public DateTime StartDate { get; set; }
    
    [Required]
    [Column("end_date")]
    public DateTime EndDate { get; set; }
    
    private bool this[DayOfWeek dayOfWeek]
    {
      get
      {
        switch (dayOfWeek)
        {
          case DayOfWeek.Sunday:
            return (Mask & 64) > 0;
          case DayOfWeek.Monday:
            return (Mask & 1) > 0;
          case DayOfWeek.Tuesday:
            return (Mask & 2) > 0;
          case DayOfWeek.Wednesday:
            return (Mask & 4) > 0;
          case DayOfWeek.Thursday:
            return (Mask & 8) > 0;
          case DayOfWeek.Friday:
            return (Mask & 16) > 0;
          case DayOfWeek.Saturday:
            return (Mask & 32) > 0;
          default:
            throw new ArgumentOutOfRangeException("Not a valid day of the week.");
        }
      }
      set
      {
        if (value)
        {
          switch (dayOfWeek)
          {
            case DayOfWeek.Sunday:
              Mask |= 64;
              break;
            case DayOfWeek.Monday:
              Mask |= 1;
              break;
            case DayOfWeek.Tuesday:
              Mask |= 2;
              break;
            case DayOfWeek.Wednesday:
              Mask |= 4;
              break;
            case DayOfWeek.Thursday:
              Mask |= 8;
              break;
            case DayOfWeek.Friday:
              Mask |= 16;
              break;
            case DayOfWeek.Saturday:
              Mask |= 32;
              break;
          }
        }
        else
        {
          switch (dayOfWeek)
          {
            case DayOfWeek.Sunday:
              Mask &= 63;
              break;
            case DayOfWeek.Monday:
              Mask &= 126;
              break;
            case DayOfWeek.Tuesday:
              Mask &= 125;
              break;
            case DayOfWeek.Wednesday:
              Mask &= 123;
              break;
            case DayOfWeek.Thursday:
              Mask &= 119;
              break;
            case DayOfWeek.Friday:
              Mask &= 111;
              break;
            case DayOfWeek.Saturday:
              Mask &= 95;
              break;
          }
        }
      }
    }
}