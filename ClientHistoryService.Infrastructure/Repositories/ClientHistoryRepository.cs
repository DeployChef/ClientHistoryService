using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClientHistoryService.Domain.Interfaces;
using ClientHistoryService.Domain.Models;

namespace ClientHistoryService.Infrastructure.Repositories
{
    public class ClientHistoryRepository : IClientHistoryRepository
    {
        public async Task<IReadOnlyCollection<CommunicationType>> GetCommunicationTypesAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
