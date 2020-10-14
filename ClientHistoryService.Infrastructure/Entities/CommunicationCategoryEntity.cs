using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientHistoryService.Infrastructure.Entities
{
    [Table("communication_category")]
    public class CommunicationCategoryEntity
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