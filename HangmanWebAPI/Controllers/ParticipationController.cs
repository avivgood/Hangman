using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HangmanWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipationController : ControllerBase
    {

        // GET api/<ParticipationController>/5
        [HttpGet ("{pid, gid}")]
        public string Get(int pid,  int gid)
        {
            return "value";
        }

        // POST api/<ParticipationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ParticipationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ParticipationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
