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
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(addCharacterDto newCharacter)
        {

            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<UpdateCharacterDto>>>> updatedCharacter(UpdateCharacterDto updatedCharacter)
        {
            var response = await _characterService.UpdateCharacter(updatedCharacter);
            if (response.Data is null) {
                return NotFound(response);
            }
            return Ok(await _characterService.UpdateCharacter(updatedCharacter));
        }

                [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> DeleteCharacter(int id)
        {

            var response = await _characterService.DeleteCharacter(id);
            if (response.Data is null) {
                return NotFound(response);
            }
            return Ok(response);        }
        
    }
}