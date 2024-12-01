using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProjetoRPG.Classes;
using ProjetoRPG.Domain.DTOs;
using ProjetoRPG.Enums;
using ProjetoRPG.Game;
using ProjetoRPG.Service;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Controller;

public class PlayerController(ServPlayer serv): BaseController<Player>(serv)
{
    [HttpPost("NewPlayer")]
    public async Task<IActionResult> NewPlayer([FromBody] NewPlayerDto dto)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var ret = await serv.NewPlayer(dto);
            
            return Ok(ret);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> OpenInventory([FromBody] int playerId)
    {
        try
        {
            return Ok(await serv.OpenInventoryAsync(playerId));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    } 
    
    [HttpPost]
    public async Task<IActionResult> UseItem([FromBody] UseItemDto dto)
    {
        try
        {
            await serv.UseItem(dto);
            return Ok();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    
    public async Task<IActionResult> GetEquipments([FromBody] int playerId)
    {
        try
        {
            return Ok(await serv.GetEquipments(playerId));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    
    public async Task<IActionResult> GetEnemy([FromBody] int playerId)
    {
        try
        {
            return Ok(await serv.GetEnemy(playerId));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    } 
}