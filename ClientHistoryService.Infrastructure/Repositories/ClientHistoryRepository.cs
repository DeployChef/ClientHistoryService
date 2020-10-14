﻿using System.Collections.Generic;
using System.Linq;
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

        public async Task<IReadOnlyCollection<CommunicationType>> GetCommunicationTypesAsync(CancellationToken cancellationToken)
        {
            var types = await _context.CommunicationTypes.Select(c => c.ToModel()).ToListAsync(cancellationToken);
            return types;
        }

        public async Task<IReadOnlyCollection<DeliveryChannel>> GetDeliveryChannelsAsync(CancellationToken cancellationToken)
        {
            var channels = await _context.DeliveryChannels.Include(i => i.Group).Select(c => c.ToModel()).ToListAsync(cancellationToken);
            return channels;
        }
    }
}
