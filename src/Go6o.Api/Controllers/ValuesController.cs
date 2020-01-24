using System;
using Go6o.Core.Application.TestEvaluators;
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
            var evaluator = ABTestEvaluatorFactory.CreateInstance(testId);

            return evaluator.GetValue();
        }
    }
}
