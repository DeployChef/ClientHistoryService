using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClientHistoryService.Domain.Models;

namespace ClientHistoryService.Domain.Interfaces
{
    public interface IClientHistoryRepository
    {
        Task<IReadOnlyCollection<CommunicationType>> GetCommunicationTypesAsync(CancellationToken token);
    }
}
