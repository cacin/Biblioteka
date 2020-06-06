using AutoMapper;
using BibliotekaApi.Models;
using BibliotekaWeb.HttpClient;
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
        }
    }
}
