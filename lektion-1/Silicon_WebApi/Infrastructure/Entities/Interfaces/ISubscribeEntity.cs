namespace Infrastructure.Entities.Interfaces
{
    public interface ISubscribeEntity
    {
        bool? AdvertisingUpdates { get; set; }
        bool? DailyNewsletter { get; set; }
        string Email { get; set; }
        bool? EventUpdates { get; set; }
        bool? Podcasts { get; set; }
        bool? StartupsWeekly { get; set; }
        bool? WeekinReview { get; set; }
    }
}