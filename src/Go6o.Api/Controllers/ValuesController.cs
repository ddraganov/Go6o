using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Go6o.Api.Controllers
{
    [ApiController]
    [Route("go6o/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{testId}")]
        public string Get([FromRoute]string testId)
        {
            return new Random().Next() % 2 == 0 ? "A" : "B";
        }
    }
}
