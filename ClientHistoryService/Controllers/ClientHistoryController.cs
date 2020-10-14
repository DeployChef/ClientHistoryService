using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using ClientHistoryService.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            _logger = logger;
        }

        [HttpGet("type")]
        public async Task<IActionResult> GetTypes(CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpGet("channel")]
        public async Task<IActionResult> GetChannels(CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpGet("communication")]
        public async Task<IActionResult> GetCommunications([Required] long clientId, [Required] DateTime dateAfter,
            DateTime? dateBefore, [FromQuery] List<int> typeIds, [FromQuery] List<int> channelIds, long? managerId,
            CancellationToken cancellationToken)
        {
            return Ok();
        }
    }
}