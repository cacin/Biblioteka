using AutoMapper;
using BibliotekaWeb.Models;
using BibliotekaWeb.HttpClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekaWeb
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PozycjaViewModel, Pozycja>().ReverseMap();
            CreateMap<HistoriaViewModel, Historia>().ReverseMap();
        }
    }
}
