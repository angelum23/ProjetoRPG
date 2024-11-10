using ProjetoRPG.Enums;

namespace ProjetoRPG.Domain.DTOs;

public record NewPlayerDto(string Name, EnumClassType ClassType);