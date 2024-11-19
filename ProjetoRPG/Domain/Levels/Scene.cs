﻿using ProjetoRPG.Base;
using ProjetoRPG.Enums;

namespace ProjetoRPG.Levels;

public abstract class Scene : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public EnumSceneType SceneType { get; set; }
    public Scene NextScene { get; set; }
}