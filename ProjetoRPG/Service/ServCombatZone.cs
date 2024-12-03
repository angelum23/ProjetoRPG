using ProjetoRPG.Classes.Base;
using ProjetoRPG.Levels;
using ProjetoRPG.Levels.Base;
using ProjetoRPG.Repository;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Service;

public class ServCombatZone : BaseService<CombatZone>, ISceneService
{
    private readonly RepCombatZone? _repCombatZone;
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
        playerCharacter.Attack(enemyCharacter);

        if (!enemyCharacter.IsAlive)
        {
            return;
        }
        
        enemyCharacter.Attack(playerCharacter);
    }
    
    public async Task SaveAsync(IScene entity)
    {
        await base.SaveAsync((CombatZone)entity);
    }
    
    public new async Task<IScene> GetByIdAsync(int id)
    {
        return await base.GetByIdAsync(id);
    }
}