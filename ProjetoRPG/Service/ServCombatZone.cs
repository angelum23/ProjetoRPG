using ProjetoRPG.Classes.Base;
using ProjetoRPG.Enums;
using ProjetoRPG.Infra;
using ProjetoRPG.Levels;
using ProjetoRPG.Levels.Base;
using ProjetoRPG.Repository;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Service;

public class ServCombatZone : BaseServiceSubject<CombatZone>, ISceneService
{
    private readonly RepCombatZone _repCombatZone;
    private readonly ServCharacter _servCharacter;
    public ServCombatZone(IServiceProvider serviceProvider) : base(serviceProvider.GetRequiredService<RepCombatZone>())
    {
        _repCombatZone = serviceProvider.GetRequiredService<RepCombatZone>();
        _servCharacter = serviceProvider.GetRequiredService<ServCharacter>();
    }
    
    public async Task Act(IScene scene, Character playerCharacter)
    {
        if (scene is not CombatZone combatZone)
        {
            throw new ArgumentException("Scene is not a combat zone.");
        }
        
        var enemyCharacter = await _servCharacter.GetByIdAsync(combatZone.IdEnemy);
        _servCharacter.Attack(playerCharacter, enemyCharacter);

        if (!enemyCharacter.IsAlive)
        {
            return;
        }
        
        _servCharacter.Attack(enemyCharacter, playerCharacter);
    }
    
    public async Task SaveAsync(IScene entity)
    {
        await base.SaveAsync((CombatZone)entity);
    }
    
    public new async Task<IScene> GetByIdAsync(int id)
    {
        return await base.GetByIdAsync(id);
    }

    public async Task Update(EnumObserverTrigger trigger, int? id = null)
    {
        var zone = _repCombatZone.Get().FirstOrDefault(cz => cz.IdEnemy == id);
        if (zone == null)
        {
            return;
        }
        
        AsyncHelper.FireAndForget(NotifyObservers(EnumObserverTrigger.OnSceneEnd, zone.Id));
    }
    
    public async Task<bool> WillDropLoot(CombatZone combatZone)
    {
        var odd = new Random().Next(1, 100);
        return combatZone.DropPerc >= odd;
    } 
}