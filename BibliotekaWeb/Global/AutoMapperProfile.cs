﻿using AutoMapper;
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
            CreateMap<BibliotekaDb.Entities.Pozycja, BibliotekaWeb.HttpClients.Pozycja>().ReverseMap();
            CreateMap<BibliotekaDb.Entities.Historia, BibliotekaWeb.HttpClients.Historia>().ReverseMap();

        }
    }
}
