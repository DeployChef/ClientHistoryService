using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClientHistoryService.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class ClientHistoryController : Controller
    {
        private readonly ILogger<ClientHistoryController> _logger;

        public ClientHistoryController(ILogger<ClientHistoryController> logger)
        {
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