using Infrastructure.Entities;
using Infrastructure.Models;
using System.Diagnostics;

namespace Infrastructure.Factories;

public class SubscribeFactory
{
    public static SubscribeEntity Create(SubscribeModel model)
    {
        try
        {
            return new SubscribeEntity
            {
                Email = model.Email,
                DailyNewsletter = model.DailyNewsletter,
                EventUpdates = model.EventUpdates,
                AdvertisingUpdates = model.AdvertisingUpdates,
                Podcasts = model.Podcasts,  
                StartupsWeekly = model.StartupsWeekly,  
                WeekinReview = model.WeekinReview        
            };
        }
        catch (Exception ex) 
        { 
            Debug.WriteLine(ex.Message  );
        }

        return null!;
    }

    public static SubscribeModel Create(SubscribeEntity entity)
    {
        try
        {
            return new SubscribeModel
            {
                Email = entity.Email,
                DailyNewsletter = entity.DailyNewsletter ?? false,
                EventUpdates = entity.EventUpdates ?? false,
                AdvertisingUpdates = entity.AdvertisingUpdates ?? false,
                Podcasts = entity.Podcasts ?? false,
                StartupsWeekly = entity.StartupsWeekly ?? false,
                WeekinReview = entity.WeekinReview ?? false
            };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return null!;
    }
}
