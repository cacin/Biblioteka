using AutoMapper;
using BibliotekaApi.Models;
using BibliotekaWeb.HttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PozycjaViewModel, Pozycja>().ReverseMap();
        }
    }
}
