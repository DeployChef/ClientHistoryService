using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ClientHistoryService.Domain.Interfaces;
using ClientHistoryService.Domain.Models;
using ClientHistoryService.Domain.Results;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace ClientHistoryService.Domain.Services
{
    public class ClientHistoryService : IClientHistoryService
    {
        private readonly IClientHistoryRepository _repo;
        private readonly ILogger<ClientHistoryService> _logger;

        public ClientHistoryService(IClientHistoryRepository repo, ILogger<ClientHistoryService> logger)
        {
            _repo = repo;
            _logger = logger ?? new NullLogger<ClientHistoryService>();
        }

        public async Task<Result<ClientHistoryServiceResults, IReadOnlyCollection<CommunicationType>>> GetCommunicationTypesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var types = await _repo.GetCommunicationTypesAsync(cancellationToken);
                return new Result<ClientHistoryServiceResults, IReadOnlyCollection<CommunicationType>>(ClientHistoryServiceResults.Success, types);
            }
            catch (Exception e)
            {
               _logger.LogError(e.Message);
               return new Result<ClientHistoryServiceResults, IReadOnlyCollection<CommunicationType>>(ClientHistoryServiceResults.Error, null, e.Message);
            }
        }

        public async Task<Result<ClientHistoryServiceResults, IReadOnlyCollection<DeliveryChannel>>> GetDeliveryChannelsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var channels = await _repo.GetDeliveryChannelsAsync(cancellationToken);
                return new Result<ClientHistoryServiceResults, IReadOnlyCollection<DeliveryChannel>>(ClientHistoryServiceResults.Success, channels);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new Result<ClientHistoryServiceResults, IReadOnlyCollection<DeliveryChannel>>(ClientHistoryServiceResults.Error, null, e.Message);
            }
        }
    }
}