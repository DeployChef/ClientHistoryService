using System;
using System.Collections.Generic;

namespace ClientHistoryService.Domain.Models
{
    public class CommunicationHistoryRequest
    {
        public long ClientId { get; set; }

        public DateTime DateAfter { get; set; }

        public DateTime? DateBefore { get; set; }

        public List<long> TypeIds { get; set; }

        public List<long> ChannelIds { get; set; }

        public long? ManagerId { get; set; }
    }
}