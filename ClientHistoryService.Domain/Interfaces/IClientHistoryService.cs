﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ClientHistoryService.Domain.Models;
using ClientHistoryService.Domain.Results;

namespace ClientHistoryService.Domain.Interfaces
{
    public interface IClientHistoryService
    {
        Task<Result<ClientHistoryServiceResults, IReadOnlyCollection<CommunicationType>>> GetCommunicationTypesAsync(CancellationToken token = default);
    }
}