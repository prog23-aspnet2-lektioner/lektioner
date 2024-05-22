using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class SubscribeFactory
{
    public static SubscribeEntity Create(SubscribeModel model)
    {
        return new SubscribeEntity
        {
            Email = model.Email,
            DailyNewsletter = model.DailyNewsletter,
            AdvertisingUpdates = model.AdvertisingUpdates,
            WeekinReview = model.WeekinReview,
            EventUpdates = model.EventUpdates,
            StartupsWeekly = model.StartupsWeekly,
            Podcasts = model.Podcasts,
            Created = DateTime.Now,
            LastUpdated = DateTime.Now,
        };
    }

    public static SubscribeModel Create(SubscribeEntity entity)
    {
        return new SubscribeModel
        {
            Email = entity.Email,
            DailyNewsletter = entity.DailyNewsletter,
            AdvertisingUpdates = entity.AdvertisingUpdates,
            WeekinReview = entity.WeekinReview,
            EventUpdates = entity.EventUpdates,
            StartupsWeekly = entity.StartupsWeekly,
            Podcasts = entity.Podcasts
        };
    }

    public static IEnumerable<SubscribeModel> CreateList(List<SubscribeEntity> entities)
    {
        var list = new List<SubscribeModel>();
        entities.ForEach(entity => list.Add(Create(entity)));

        return list;
    }

    public static SubscribeEntity Update(SubscribeEntity entity, SubscribeModel model)
    {

        entity.DailyNewsletter = model.DailyNewsletter;
        entity.AdvertisingUpdates = model.AdvertisingUpdates;
        entity.WeekinReview = model.WeekinReview;
        entity.EventUpdates = model.EventUpdates;
        entity.StartupsWeekly = model.StartupsWeekly;
        entity.Podcasts = model.Podcasts;
        entity.Created = entity.Created;
        entity.LastUpdated = DateTime.Now;

        return entity;
    }

}
