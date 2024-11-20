using ProjetoRPG.Enums;

namespace ProjetoRPG.Levels.DTOs;

public record AddSceneDto(int LevelId, int SceneId, int PrevSceneId, EnumSceneType SceneType);