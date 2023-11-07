global using dotnet_rpg.models;
global using dotnet_rpg.Services.CharacterService;
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

        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }
        public static Character knight = new Character();

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetCharacterDto>>> Get()
        {   
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {

            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(Character newCharacter)
        {

            return Ok(await _characterService.AddCharacter(newCharacter));
        }
    }
}