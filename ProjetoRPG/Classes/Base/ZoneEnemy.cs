﻿using ProjetoRPG.Items.Base;

namespace ProjetoRPG.Base;

public class ZoneEnemy
{
    public Character Character { get; set; }
    public int DropPerc { get; set; } = 100;
    public List<Item> Loots { get; set; }
}