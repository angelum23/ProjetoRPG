using ProjetoRPG.Classes.Base;
using ProjetoRPG.Domain.Classes;
using ProjetoRPG.Domain.DTOs;
using ProjetoRPG.Enums;

namespace ProjetoRPG.Classes;

public static class CharacterFabric
{
    public static Character CreateCharacter(EnumClassType classType, CreateCharacterDto dto)
    {
        switch (classType)
        {
            case EnumClassType.Necromancer:
                return BaseClassesAtributes.Necromancer(dto);
            case EnumClassType.Ninja:
                return BaseClassesAtributes.Ninja(dto);
            case EnumClassType.Paladin:
                return BaseClassesAtributes.Paladin(dto);
            case EnumClassType.Priest:
                return BaseClassesAtributes.Priest(dto);
            case EnumClassType.Samurai:
                return BaseClassesAtributes.Samurai(dto);
            case EnumClassType.Wizard:
                return BaseClassesAtributes.Wizard(dto);
            default:
                throw new ArgumentException("Invalid class type.");
        }
    }
}