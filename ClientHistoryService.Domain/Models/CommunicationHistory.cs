using System;

namespace ClientHistoryService.Domain.Models
{
    public class CommunicationHistory
    {
        public long Id { get; set; }

        public long CategoryId { get; set; }

        public long TypeId { get; set; }
        
        public DateTime Sent { get; set; }
        
        public DateTime? Received { get; set; }
        
        public long ClientId { get; set; }

        public long DeliveryChannelId { get; set; }
   
        public int Route { get; set; }
        
        public long? ManagerId { get; set; }
        
        public string Product { get; set; }
        
        public string Message { get; set; }
    }
}