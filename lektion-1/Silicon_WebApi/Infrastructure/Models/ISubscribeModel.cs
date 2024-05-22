namespace Infrastructure.Models
{
    public interface ISubscribeModel
    {
        bool AdvertisingUpdates { get; set; }
        bool DailyNewsletter { get; set; }
        string Email { get; set; }
        bool EventUpdates { get; set; }
        bool Podcasts { get; set; }
        bool StartupsWeekly { get; set; }
        bool WeekinReview { get; set; }
    }
}