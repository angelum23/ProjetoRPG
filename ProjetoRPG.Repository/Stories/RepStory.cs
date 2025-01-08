using ProjetoRPG.Domain.Levels;
using ProjetoRPG.Infra;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository;

public class RepStory : BaseRepDbSet<Story>
{
    public RepStory(ApplicationDbContext context) : base(context)
    {
    }
}
