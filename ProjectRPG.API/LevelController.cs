using Microsoft.AspNetCore.Mvc;
using ProjetoRPG.Base;
using ProjetoRPG.Domain.DTOs;
using ProjetoRPG.Domain.Levels;
using ProjetoRPG.Service;

namespace ProjetoRPG;

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