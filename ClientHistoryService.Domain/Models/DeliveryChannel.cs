
namespace ClientHistoryService.Domain.Models
{
    public class DeliveryChannel
    {
        public long Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public long GroupId { get; set; }
    }
}