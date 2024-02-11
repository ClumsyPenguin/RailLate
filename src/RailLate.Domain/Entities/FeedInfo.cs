using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailLate.Domain.Entities;

public class FeedInfo : GtfsEntity
{
    [Required]
    [Column("feed_publisher_name")]
    public string PublisherName { get; set; }
    
    [Required]
    [Column("feed_publisher_url")]
    public string PublisherUrl { get; set; }
    
    [Required]
    [Column("feed_lang")]
    public string Lang { get; set; }
    
    [Column("feed_start_date")]
    public string StartDate { get; set; }
    
    [Column("feed_end_date")]
    public string EndDate { get; set; }
    
    [Column("feed_version")]
    public string Version { get; set; }
}