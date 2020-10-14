
namespace ClientHistoryService.Domain.Models
{
    public class DeliveryChannel
    {
        public long Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public DeliveryChannelGroup Group { get; set; }
    }
}