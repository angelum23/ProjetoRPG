using Microsoft.EntityFrameworkCore;
using ProjetoRPG.Classes;
using ProjetoRPG.Domain.DTOs;
using ProjetoRPG.Enums;
using ProjetoRPG.Game;
using ProjetoRPG.Repository;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Service;

public class PlayerService(RepPlayer rep) : BaseService<Player>(rep)
{
    public override Task<Player> Save(Player entity)
    {
        throw new NotSupportedException();
    }
    
    public async Task<Player> NewPlayer(NewPlayerDto dto)
    {
        if (rep.Get().Any())
        {
            throw new ArgumentException("Player already exists");
        }
        
        var characterDto = new CreateCharacterDto(dto.Name, EnumMobType.Player);
        
        var player = new Player
        {
            Character = CharacterFabric.CreateCharacter(dto.ClassType, characterDto),
            Inventory = new Inventory(),
        };

        await rep.SaveAsync(player);
        return player;
    }
    
    public async Task<Player> GetPlayer()
    {
        var player = await rep.Get().SingleAsync();
        return player;
    }
    
    public async Task DeletePlayer()
    {
        var player = await GetPlayer();
        player.Remove();
        await rep.SaveAsync(player);
    }
}