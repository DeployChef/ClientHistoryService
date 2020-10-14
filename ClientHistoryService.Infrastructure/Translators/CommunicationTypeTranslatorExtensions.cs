using System;
using System.Collections.Generic;
using System.Text;
using ClientHistoryService.Domain.Models;
using ClientHistoryService.Infrastructure.Entities;

namespace ClientHistoryService.Infrastructure.Translators
{
    public static class CommunicationTypeTranslatorExtensions
    {
        public static CommunicationType ToModel(this CommunicationTypeEntity entity)
        {
            return new CommunicationType()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };
        }
    }
}
