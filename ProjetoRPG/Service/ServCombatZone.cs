using ProjetoRPG.Levels;
using ProjetoRPG.Levels.Base;
using ProjetoRPG.Repository;
using ProjetoRPG.Repository.Base;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Service;

public class ServCombatZone : BaseService<CombatZone>, ISceneService
{
    private readonly RepCombatZone? _repCombatZone;
    public ServCombatZone(IServiceProvider serviceProvider) : base(serviceProvider.GetRequiredService<RepCombatZone>())
    {
        _repCombatZone = serviceProvider.GetRequiredService<RepCombatZone>();
    }
    
    public void Act()
    {
        throw new NotImplementedException();
    }

    public void StartNextScene()
    {
        throw new NotImplementedException();
    }

    public async Task Save(IScene entity)
    {
        await base.SaveAsync((CombatZone)entity);
    }
}