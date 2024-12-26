using ProjetoRPG.Domain.Enums;

namespace ProjetoRPG.Domain.DTOs;

public record CreateCharacterDto(string Name, EnumMobType MobType);
public record NewCharacterDto(string Name, EnumMobType MobType, EnumClassType ClassType) : CreateCharacterDto(Name, MobType);
