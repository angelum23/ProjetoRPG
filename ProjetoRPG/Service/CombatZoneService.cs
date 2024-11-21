﻿using ProjetoRPG.Levels;
using ProjetoRPG.Levels.Base;
using ProjetoRPG.Repository;
using ProjetoRPG.Repository.Base;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Service;

public class CombatZoneService : BaseService<CombatZone>, ISceneService
{
    private readonly RepCombatZone? _repCombatZone;
    public CombatZoneService(IServiceProvider serviceProvider) : base(serviceProvider.GetService<RepCombatZone>())
    {
        _repCombatZone = serviceProvider.GetService<RepCombatZone>();
    }
    
    public void Act()
    {
        throw new NotImplementedException();
    }

    public void StartNextScene()
    {
        throw new NotImplementedException();
    }

    public new Task<Scene?> GetByIdAsync(int sceneId)
    {
        throw new NotImplementedException();
    }
}