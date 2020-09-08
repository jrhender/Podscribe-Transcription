using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace podscribe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranscriptController : ControllerBase
    {
        private readonly ILogger<TranscriptController> _logger;

        public TranscriptController(ILogger<TranscriptController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Transcript> Get()
        {
            return new Transcript[] { new Transcript() { text = "test!" } };
        }
    }
}
