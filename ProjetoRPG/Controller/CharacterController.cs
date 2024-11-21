using Microsoft.AspNetCore.Mvc;
using ProjetoRPG.Classes;
using ProjetoRPG.Classes.Base;
using ProjetoRPG.Domain.DTOs;
using ProjetoRPG.Service;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Controller;

public class CharacterController(CharacterService serv) : BaseController<Character>(serv)
{
    public override Task<IActionResult> Save(Character entity)
    {
        throw new NotSupportedException("Use NewCharacter endpoint.");
    }

    [HttpPost]  
    public virtual async Task<IActionResult> NewCharacter([FromBody] NewCharacterDto dto)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var ret = await serv.Save(CharacterFabric.CreateCharacter(dto.ClassType, dto));
            
            return Ok(ret);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    } 
}