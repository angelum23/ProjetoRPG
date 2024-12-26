using ProjetoRPG.Domain.Levels;
using ProjetoRPG.Infra;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository;

public class RepStory : RepBaseDbSet<Story>
{
    public RepStory(ApplicationDbContext context) : base(context)
    {
    }
}
