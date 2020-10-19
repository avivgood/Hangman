using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HangmanAPI.Wrappers;
using Microsoft.AspNetCore.Mvc;
using HangmanDataLayer;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HangmanWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private IRepo<PlayerWrapperClass> repo;
        public PlayerController()
        {
            repo = new PlayerRepo();
        }
        // GET api/<PlayerController>/5
        [HttpGet]
        public async Task<PlayerWrapperClass> Get([FromBody] int pid)
        {
            return await repo.ReadAsync(pid);
        }

        // POST api/<PlayerController>
        [HttpPost]
        public async Task Post([FromBody] PlayerWrapperClass player)
        {
            await repo.WriteAsync(player);
        }

        // PUT api/<PlayerController>/5
        [HttpPut]
        public async Task Put([FromBody] PlayerWrapperClass value)
        {
            await repo.ModifyAsync(value);
        }

        // DELETE api/<PlayerController>/5
        [HttpDelete]
        public async Task Delete([FromBody] int pid)
        {
            await repo.DeleteAsync(pid);
        }
    }
}
