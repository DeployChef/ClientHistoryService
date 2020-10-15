﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ClientHistoryService.Domain.Interfaces;
using ClientHistoryService.Domain.Models;
using ClientHistoryService.Domain.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace ClientHistoryService.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class ClientHistoryController : Controller
    {
        private readonly IClientHistoryService _service;
        private readonly ILogger<ClientHistoryController> _logger;

        public ClientHistoryController(IClientHistoryService service, ILogger<ClientHistoryController> logger)
        {
            _service = service;
            _logger = logger ?? new NullLogger<ClientHistoryController>();
        }

        [HttpGet("type")]
        public async Task<IActionResult> GetTypes(CancellationToken cancellationToken)
        {
            var typesResult = await _service.GetCommunicationTypesAsync(cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();

            switch (typesResult.Value)
            {
                case ClientHistoryServiceResults.Success:
                    return Ok(typesResult.Data);
                case ClientHistoryServiceResults.Error:
                    return Problem(typesResult.Message);
                default:
                    return Problem("sorry :(");
            }
        }

        [HttpGet("channel")]
        public async Task<IActionResult> GetChannels(CancellationToken cancellationToken)
        {
            var channelsResult = await _service.GetDeliveryChannelsAsync(cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();

            switch (channelsResult.Value)
            {
                case ClientHistoryServiceResults.Success:
                    return Ok(channelsResult.Data);
                case ClientHistoryServiceResults.Error:
                    return Problem(channelsResult.Message);
                default:
                    return Problem("sorry :(");
            }
        }

        [HttpGet("communication")]
        public async Task<IActionResult> GetCommunications([Required] long clientId, [Required] DateTime dateAfter,
            DateTime? dateBefore, [FromQuery] List<long> typeIds, [FromQuery] List<long> channelIds, long? managerId,
            CancellationToken cancellationToken)
        {
            var communicationHistoryResult = await _service.GetCommunicationHistoryAsync(new CommunicationHistoryRequest
            {
                ClientId = clientId,
                DateAfter = dateAfter,
                DateBefore = dateBefore,
                TypeIds = typeIds != null ? typeIds.ToList() : new List<long>(),
                ChannelIds = channelIds != null ? channelIds.ToList() : new List<long>(),
                ManagerId = managerId
            }, cancellationToken);
            
            switch (communicationHistoryResult.Value)
            {
                case ClientHistoryServiceResults.Success:
                    return Ok(communicationHistoryResult.Data);
                case ClientHistoryServiceResults.Error:
                    return Problem(communicationHistoryResult.Message);
                default:
                    return Problem("sorry :(");
            }
        }
    }
}