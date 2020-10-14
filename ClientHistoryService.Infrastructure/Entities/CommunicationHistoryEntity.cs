using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientHistoryService.Infrastructure.Entities
{
    [Table("communication_history")]
    public class CommunicationHistoryEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        
        [ForeignKey(nameof(Category))]
        [Column("category_id")]
        public long CategoryId { get; set; }
        
        [ForeignKey(nameof(Type))]
        [Column("type_id")]
        public long TypeId { get; set; }
        
        [Column("dt_sent")]
        public DateTime Sent { get; set; }
        
        [Column("dt_received")]
        public DateTime? Received { get; set; }
        
        [Column("client_id")]
        public long ClientId { get; set; }
        
        [ForeignKey(nameof(DeliveryChannel))]
        [Column("delivery_channel_id")]
        public long DeliveryChannelId { get; set; }
        
        [Column("route")]
        public int Route { get; set; }
        
        [Column("manager_id")]
        public long? ManagerId { get; set; }
        
        [Column("product")]
        public string Product { get; set; }
        
        [Column("message")]
        public string Message { get; set; }
        
        #region Navigation Properties

        public CommunicationCategoryEntity Category { get; set; }
        
        public CommunicationTypeEntity Type { get; set; }
        
        public DeliveryChannelEntity DeliveryChannel { get; set; }

        #endregion
    }
}