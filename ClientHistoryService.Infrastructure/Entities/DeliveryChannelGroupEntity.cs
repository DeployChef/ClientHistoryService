using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientHistoryService.Infrastructure.Entities
{
    [Table("delivery_channel_group")]
    public class DeliveryChannelGroupEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
        
        [Column("description")]
        public string Description { get; set; }
    }
}