using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using HangmanAPI.Enums;
using HangmanAPI.WordGeneration;
using HangmanAPI.Wrappers;
using HangmanDataLayer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HangmanWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private const int idLengthPolicy = 5;
        private GameRepo repo = new GameRepo();

        private const int triesNo = 10; 
        // GET: api/<GameController>
        [HttpGet]
        public async Task<GameWrapperClass> Get()
        {
            IUniqueIdGen idGen = new UniqueIdGen<GameWrapperClass>(repo);
            IWordGenerator wordGen = new RandomWordGenerator();
            GameWrapperClass newGame = new  GameWrapperClass((await idGen.GetUniqueIdAsync(idLengthPolicy)), (await wordGen.GetWordAsync()), triesNo);
            await repo.WriteAsync(newGame);
            return newGame;
        }

        [HttpGet]
        public async Task<GameWrapperClass> Get([FromBody] WordTopic topic)
        {
            IUniqueIdGen idGen = new UniqueIdGen<GameWrapperClass>(repo);
            IWordGenerator wordGen = new ConstentWordGenerator(topic);
            GameWrapperClass newGame = new GameWrapperClass((await idGen.GetUniqueIdAsync(idLengthPolicy)), (await wordGen.GetWordAsync()), triesNo);
            await repo.WriteAsync(newGame);
            return newGame;
        }

        // GET api/<GameController>/5
        [HttpGet]
        public async Task<GameWrapperClass> Get([FromBody] int gid)
        {
            return await repo.ReadAsync(gid);
        }

        // POST api/<GameController>
        [HttpPost]
        public async Task Post([FromBody] GameWrapperClass game)
        {
            await repo.WriteAsync(game);
        }

        // PUT api/<GameController>/5
        [HttpPut]
        public async Task Put([FromBody] GameWrapperClass game)
        {
            await repo.ModifyAsync(game);
        }

        // DELETE api/<GameController>/5
        [HttpDelete]
        public async Task Delete([FromBody] int id)
        {
            await repo.DeleteAsync(id);
        }
    }
}
