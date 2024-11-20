﻿using Microsoft.AspNetCore.Mvc;
using ProjetoRPG.Service;
using ProjetoRPG.Service.Base;


namespace ProjetoRPG.Controller;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseRawController<T> : ControllerBase
{
    #region Ctor

    protected readonly IBaseService<T> _service;

    public BaseRawController(IBaseService<T> service)
    {
        _service = service;
    }

    #endregion
    
    [HttpGet]
    public virtual async Task<IActionResult> Get()
    {
        try
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpGet("{id:int}")]
    public virtual async Task<IActionResult> Get(int id)
    {
        try
        {
            var item = await _service.GetByIdAsync(id);
            return Ok(item);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpPost]
    [HttpPut]
    public virtual async Task<IActionResult> Save([FromBody] T entity)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var ret = await _service.Save(entity);
            
            return Ok(ret);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public virtual async Task<IActionResult> HardDelete(int id)
    {
        try
        {
            await _service.HardDeleteAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpPatch("remove/{id:int}")]
    public virtual async Task<IActionResult> Remove(int id)
    {
        try
        {
            await _service.RemoveAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}