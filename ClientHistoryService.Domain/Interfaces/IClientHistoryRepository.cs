using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ClientHistoryService.Domain.Models;

namespace ClientHistoryService.Domain.Interfaces
{
    public interface IClientHistoryRepository
    {
        Task<IReadOnlyCollection<CommunicationType>> GetCommunicationTypesAsync(CancellationToken cancellationToken);
        
        Task<IReadOnlyCollection<DeliveryChannel>> GetDeliveryChannelsAsync(CancellationToken cancellationToken);
        
        Task<IReadOnlyCollection<CommunicationHistory>> GetCommunicationHistoryAsync(CommunicationHistoryRequest communicationHistoryRequest, CancellationToken cancellationToken);
    }
}
