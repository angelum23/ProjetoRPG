using Microsoft.AspNetCore.Mvc;
using ProjetoRPG.Domain.DTOs;
using ProjetoRPG.Enums;
using ProjetoRPG.Levels;
using ProjetoRPG.Levels.DTOs;
using ProjetoRPG.Service;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Controller;

public class LevelController : BaseController<Level>
{
    private readonly ServLevel _service;
    public LevelController(ServLevel service) : base(service)
    {
        _service = service;
    }
    
    public IActionResult NewLevel([FromBody] NewLevelDto levelDto)
    {
        try
        {
            var level = _service.NewLevel(levelDto);
            return Ok(level);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}