using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClientHistoryService.Domain.Interfaces;
using ClientHistoryService.Domain.Models;
using ClientHistoryService.Infrastructure.Db;
using ClientHistoryService.Infrastructure.Translators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace ClientHistoryService.Infrastructure.Repositories
{
    public class ClientHistoryRepository : IClientHistoryRepository
    {
        private readonly ClientHistoryDbContext _context;
        private readonly ILogger<ClientHistoryRepository> _logger;

        public ClientHistoryRepository(ClientHistoryDbContext context, ILogger<ClientHistoryRepository> logger)
        {
            _context = context;
            _logger = logger ?? new NullLogger<ClientHistoryRepository>();
        }

        public async Task<IReadOnlyCollection<CommunicationType>> GetCommunicationTypesAsync(CancellationToken token)
        {
            var types = await _context.CommunicationTypes.Select(c => c.ToModel()).ToListAsync(token);
            return types;
        }
    }
}
