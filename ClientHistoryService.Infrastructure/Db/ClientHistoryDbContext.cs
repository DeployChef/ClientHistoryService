using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
