using ProjetoRPG.Levels;
using ProjetoRPG.Repository.Base;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Service;

public class StoryService(IRepBase<Story> rep) : BaseService<Story>(rep)
{
}