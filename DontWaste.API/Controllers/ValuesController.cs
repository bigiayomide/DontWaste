using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DontWaste.Api.Business.Contracts;
using DontWaste.Api.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DontWaste.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IBusinessEngine _IbusinessEngine;
        public ValuesController(IBusinessEngine businessEngine)
        {
            _IbusinessEngine = businessEngine;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _IbusinessEngine.Test();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
