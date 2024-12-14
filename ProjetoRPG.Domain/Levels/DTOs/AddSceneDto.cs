using ProjetoRPG.Domain.Enums;

namespace ProjetoRPG.Domain.Levels.DTOs;

public record AddSceneDto(int LevelId, int SceneId, int PrevSceneId, EnumSceneType SceneType);