using Microsoft.EntityFrameworkCore;
using ProjetoRPG.Classes.Base;
using ProjetoRPG.Domain.Game;
using ProjetoRPG.Domain.Items;
using ProjetoRPG.Domain.Levels;

namespace ProjetoRPG.Infra;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    //Items
    public DbSet<Item> Item { get; set; }
    
    //Characters
    public DbSet<Character> Character { get; set; }
    public DbSet<Player> Player { get; set; }
    public DbSet<Inventory> Inventory { get; set; }
    
    //Level
    public DbSet<Level> Level { get; set; }
    public DbSet<CombatZone> Zone { get; set; }
}