using Microsoft.EntityFrameworkCore;
using ProjetoRPG.Classes;
using ProjetoRPG.Classes.Base;
using ProjetoRPG.Domain.DTOs;
using ProjetoRPG.Enums;
using ProjetoRPG.Game;
using ProjetoRPG.Items.Base;
using ProjetoRPG.Levels;
using ProjetoRPG.Repository;
using ProjetoRPG.Service.Base;
using ProjetoRPG.Service.Factory;

namespace ProjetoRPG.Service;

public class ServPlayer(RepPlayer rep, 
                        ServInventory servInventory, 
                        ServItem servItem, 
                        ServLevel servLevel, 
                        ServCombatZone servCombatZone, 
                        ServCharacter servCharacter,
                        ServiceProvider serviceProvider) : BaseService<Player>(rep)
{
    public override Task<Player> SaveAsync(Player entity)
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

        await servCharacter.SaveAsync(player.Character);
        player.IdCharacter = player.Character.Id;
        
        await servInventory.SaveAsync(player.Inventory);
        player.IdInventory = player.Inventory.Id;
        
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

    public async Task<List<Item>> OpenInventoryAsync(int idPlayer)
    {
        var player = await rep.GetByIdAsync(idPlayer);
        return await servInventory.OpenInventoryAsync(player.IdInventory);
    }

    public async Task UseItem(UseItemDto dto)
    {
        var item = await servItem.GetByIdAsync(dto.IdItem);
        var player = await base.GetByIdAsync(dto.IdPlayer);

        if (item.ItemType == EnumItemType.Armor)
        {
            await servInventory.EquipArmor(player.IdInventory, player.IdCharacter, item.Id);
        }
        else
        {
            await servInventory.EquipWeapon(player.IdInventory, player.IdCharacter, item.Id);
        }
    }

    public async Task<List<Item>> GetEquipments(int playerId)
    {
        return await servItem.GetEquipments(playerId);
    }

    public async Task<Character> GetEnemy(int playerId)
    {
        var player = await base.GetByIdAsync(playerId);
        var level = await servLevel.GetByIdAsync(player.IdCurrentLevel);
        if (level.ActualSceneType != EnumSceneType.CombatZone)
        {
            throw new Exception("You are not in a combat zone.");
        }

        var combatZone = (CombatZone)await servCombatZone.GetByIdAsync(level.IdActualScene);
        return await servCharacter.GetByIdAsync(combatZone.IdEnemy);
    }

    public async Task Act(ActDto dto)
    {
        var player = await base.GetByIdAsync(dto.playerId);
        var playerCharacter = await servCharacter.GetByIdAsync(player.IdCharacter);
        var level = await servLevel.GetByIdAsync(player.IdCurrentLevel);
        
        var factory = new SceneServiceFactory(serviceProvider);
        var sceneService = factory.CreateSceneService(level.ActualSceneType);
        var scene = await sceneService.GetByIdAsync(level.IdActualScene);

        await sceneService.Act(scene, playerCharacter);
    }
}