using ProjetoRPG.Levels;
using ProjetoRPG.Levels.Base;
using ProjetoRPG.Repository;
using ProjetoRPG.Repository.Base;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Service;

public class CombatZoneService(RepCombatZone rep) : BaseService<CombatZone>(rep)
{
}