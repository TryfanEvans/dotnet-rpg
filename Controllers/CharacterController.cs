global using dotnet_rpg.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

namespace dotnet_rpg.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {    
        private static List<Character> characters = new List<Character> {
        new Character(),
        new Character { Id = 0, Name = "Frond"},
        new Character { Id = 1, Name = "Sam" }
        };

        public static Character knight = new Character();

        [HttpGet("GetAll")]
        public ActionResult<List<Character>> Get()
        {
            return Ok(characters);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(characters.FirstOrDefault(c => c.Id == id));
        }
    }
}