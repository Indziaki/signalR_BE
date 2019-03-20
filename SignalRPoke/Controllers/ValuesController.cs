using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using SignalRPoke.Hubs;
using SignalRPoke.Models;
using SignalRPoke.Services;

namespace SignalRPoke.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {                                                                        
                                                
        private GenerateRandom _hostedService;

        public ValuesController(IHubContext<ValuesHub> hub, IHostedService hostedService)
        {                        
            _hostedService = hostedService as GenerateRandom;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ChartModel>> Get()
        {
            return _hostedService.numbers;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        //[HttpPost("{value}")]
        //public async void Post([FromRoute] string value)
        //{
        //    Source.Add(value);
        //    await context.Clients.All.SendAsync("Add", value);
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public async void Delete(int id)
        //{
        //    var item = Source[id];
        //    Source.Remove(item);
        //    await context.Clients.All.SendAsync("Delete", item);
        //}
    }
}
