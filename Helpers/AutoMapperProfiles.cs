using AutoMapper;
using HSPA_Web_Api.Dtos;
using HSPA_Web_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSPA_Web_Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<City, CityDto>(); // ra tipidan ra tipshi unda damapos amasgetis dros
            CreateMap<CityDto, City>(); // amas postis dros viyenebt naxe citykontrolershi am mimartulebas citydtodan citysken
        }
    }
}
