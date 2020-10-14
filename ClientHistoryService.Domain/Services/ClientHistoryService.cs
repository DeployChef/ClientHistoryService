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

        public async Task<Result<ClientHistoryServiceResults, IReadOnlyCollection<CommunicationType>>> GetCommunicationTypesAsync(CancellationToken token = default)
        {
            try
            {
                var types = await _repo.GetCommunicationTypesAsync(token);

                return new Result<ClientHistoryServiceResults, IReadOnlyCollection<CommunicationType>>(ClientHistoryServiceResults.Success, types);
            }
            catch (Exception e)
            {
               _logger.LogError(e.Message);
               return new Result<ClientHistoryServiceResults, IReadOnlyCollection<CommunicationType>>(ClientHistoryServiceResults.Error);
            }
        }
    }
}