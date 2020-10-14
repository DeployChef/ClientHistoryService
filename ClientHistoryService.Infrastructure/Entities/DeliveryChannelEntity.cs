using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientHistoryService.Infrastructure.Entities
{
    [Table("delivery_channel")]
    public class DeliveryChannelEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
        
        [Column("description")]
        public string Description { get; set; }
        
        [ForeignKey(nameof(Group))]
        [Column("group_id")]
        public long GroupId { get; set; }
        
        #region Navigation Properties

        public DeliveryChannelGroupEntity Group { get; set; }

        #endregion
    }
}