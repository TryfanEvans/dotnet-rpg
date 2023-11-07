using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg
{
    public class AutoMApperProfile : Profile
    {
        public AutoMApperProfile()
        {
            CreateMap<Character, GetCharacterDto> ();
            CreateMap<addCharacterDto, Character> ();
        }
    }
}