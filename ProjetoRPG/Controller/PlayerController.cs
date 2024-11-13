using Microsoft.AspNetCore.Mvc;
using ProjetoRPG.Classes;
using ProjetoRPG.Domain.DTOs;
using ProjetoRPG.Enums;
using ProjetoRPG.Game;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Controller;

public class PlayerController(IBaseService<Player> service) : BaseController<Player>(service)
{
    [HttpPost]
    public virtual async Task<IActionResult> NewPlayer([FromBody] NewPlayerDto dto)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var characterDto = new CreateCharacterDto(dto.Name, EnumMobType.Player);
            var player = new Player
            {
                Character = CharacterFabric.CreateCharacter(dto.ClassType, characterDto)
            };
            var ret = await _service.Save(player);
            
            return Ok(ret);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    } 
}