using ClientHistoryService.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientHistoryService.Infrastructure.Db
{
    public class ClientHistoryDbContext : DbContext
    {
        public ClientHistoryDbContext(DbContextOptions<ClientHistoryDbContext> options) : base(options)
        {
        }

        public DbSet<CommunicationTypeEntity> CommunicationTypes { get; set; }
        
        public DbSet<CommunicationCategoryEntity> CommunicationCategories { get; set; }
        
        public DbSet<CommunicationHistoryEntity> CommunicationHistory { get; set; }
        
        public DbSet<DeliveryChannelEntity> DeliveryChannels { get; set; }
        
        public DbSet<DeliveryChannelGroupEntity> DeliveryChannelGroups { get; set; }
    }
}
