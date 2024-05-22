using Infrastructure.Models;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class SubscribeEntity
{
    [Key]
    public string Email { get; set; } = null!;
    public bool DailyNewsletter { get; set; } = false;
    public bool AdvertisingUpdates { get; set; } = false;
    public bool WeekinReview { get; set; } = false;
    public bool EventUpdates { get; set; } = false;
    public bool StartupsWeekly { get; set; } = false;
    public bool Podcasts { get; set; } = false;
    public DateTime Created {  get; set; }
    public DateTime LastUpdated { get; set; }

}
