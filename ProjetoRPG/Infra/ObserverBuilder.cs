using ProjetoRPG.Service;

namespace ProjetoRPG.Infra;

public static class ObserverBuilder
{
    public static void RegisterObservers(IServiceProvider serviceProvider)
    {
        var servPlayer = serviceProvider.GetRequiredService<ServPlayer>();
        var servLevel = serviceProvider.GetRequiredService<ServLevel>();
        var servStory = serviceProvider.GetRequiredService<ServStory>();
        var servCombatZone = serviceProvider.GetRequiredService<ServCombatZone>();
        var servCharacter = serviceProvider.GetRequiredService<ServCharacter>();

        servCharacter.AddObserver(servStory);        
        servCharacter.AddObserver(servCombatZone);
        servCombatZone.AddObserver(servLevel);
        servStory.AddObserver(servLevel);
        servLevel.AddObserver(servPlayer);
        servCharacter.AddObserver(servPlayer);
    }
}