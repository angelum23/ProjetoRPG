﻿using ProjetoRPG.Domain.Enums;

namespace ProjetoRPG.Domain.Levels;

public interface IScene
{
    public string Name { get; set; }
    public string Description { get; set; }
    public EnumSceneType SceneType { get; set; }
    
    public int? IdNextScene { get; set; }
    public IScene? NextScene { get; set; }

    public int GetId();
    public bool Persisted();
}