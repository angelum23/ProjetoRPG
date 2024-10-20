using Microsoft.EntityFrameworkCore;
using ProjetoRPG.Classes.Base;
using ProjetoRPG.Game;
using ProjetoRPG.Items;
using ProjetoRPG.Items.Base;
using ProjetoRPG.Levels;

namespace ProjetoRPG.Infra;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    //Items
    public DbSet<Item> Item { get; set; }
    public DbSet<Armor> Armor { get; set; }
    public DbSet<Sword> Sword { get; set; }
    public DbSet<Shield> Shield { get; set; }
    public DbSet<Bow> Bow { get; set; }
    public DbSet<Staff> Staff { get; set; }
    
    //Characters
    public DbSet<Character> Character { get; set; }
    public DbSet<Player> Player { get; set; }
    public DbSet<Inventory> Inventory { get; set; }
    
    //Level
    public DbSet<Level> Level { get; set; }
    public DbSet<Zone> Zone { get; set; }
    public DbSet<ZoneEnemy> ZoneEnemy { get; set; }
}