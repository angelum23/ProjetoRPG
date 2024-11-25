﻿using Microsoft.EntityFrameworkCore;
using ProjetoRPG.Classes;
using ProjetoRPG.Domain.DTOs;
using ProjetoRPG.Enums;
using ProjetoRPG.Game;
using ProjetoRPG.Items.Base;
using ProjetoRPG.Repository;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Service;

public class ServPlayer(RepPlayer rep, ServInventory servInventory, ServItem servItem) : BaseService<Player>(rep)
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
            await servInventory.EquipArmor(player.IdInventory, item.Id);
        }
        else
        {
            await servInventory.EquipWeapon(player.IdInventory, item.Id);
        }
    }

    public async Task<object?> GetEquipments(int playerId)
    {
        return await servItem.GetEquipments(playerId);
    }
}