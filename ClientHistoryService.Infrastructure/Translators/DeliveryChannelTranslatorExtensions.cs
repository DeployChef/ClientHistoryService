using ClientHistoryService.Domain.Models;
using ClientHistoryService.Infrastructure.Entities;

namespace ClientHistoryService.Infrastructure.Translators
{
    public static class DeliveryChannelTranslatorExtensions
    {
        public static DeliveryChannel ToModel(this DeliveryChannelEntity entity)
        {
            var channel = new DeliveryChannel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Group = new DeliveryChannelGroup
                {
                    Id = entity.GroupId
                }
            };

            if (entity.Group != null)
            {
                channel.Group.Name = entity.Group.Name;
                channel.Group.Description = entity.Group.Description;
            }
            
            return channel;
        }
    }
}