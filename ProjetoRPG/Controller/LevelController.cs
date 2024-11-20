using ProjetoRPG.Enums;
using ProjetoRPG.Levels;
using ProjetoRPG.Levels.DTOs;
using ProjetoRPG.Service;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Controller;

public class LevelController : BaseController<Level>
{
    private readonly LevelService _service;
    public LevelController(LevelService service) : base(service)
    {
        _service = service;
    }
    
    public void AddScene(AddSceneDto dto)
    {
        try
        {
            _service.AddScene(dto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}