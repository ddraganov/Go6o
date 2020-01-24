using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Go6o.Api.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Go6o.Api.Controllers
{
    [Route("go6o/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        [HttpPost("simplecounting")]
        public void SimpleCounting([FromBody]SimpleCountingTestCreationRequest request)
        {
           
        }

        [HttpPost("successfail")]
        public void SuccessFail([FromBody]SuccessFailTestCreationRequest request)
        {

        }
    }
}