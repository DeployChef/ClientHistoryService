using ClientHistoryService.Domain.Models;
using ClientHistoryService.Infrastructure.Entities;

namespace ClientHistoryService.Infrastructure.Translators
{
    public static class CommunicationHistoryTranslatorExtensions
    {
        public static CommunicationHistory ToModel(this CommunicationHistoryEntity entity)
        {
            return new CommunicationHistory
            {
                Id = entity.Id,
                CategoryId = entity.CategoryId,
                TypeId = entity.TypeId,
                Sent = entity.Sent,
                Received = entity.Received,
                ClientId = entity.ClientId,
                DeliveryChannelId = entity.DeliveryChannelId,
                Route = entity.Route,
                ManagerId = entity.ManagerId,
                Product = entity.Product,
                Message = entity.Message
            };
        }
    }
}