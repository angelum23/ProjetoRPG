﻿using ProjetoRPG.Items.Base;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository;

public class RepItem(RepInventory repInventory) : RepBaseMemory<Item>
{
}