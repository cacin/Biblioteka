using AutoMapper;
using BibliotekaWeb.HttpClients;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BibliotekaWeb.Services
{
    public class HistoriaService : IHistoriaService
    {
        readonly HttpClient httpClient = new HttpClient();

        private readonly IMapper _mapper;
        private readonly IOptions<BibliotekaConfiguration> _config;

        public HistoriaService(IMapper mapper, IOptions<BibliotekaConfiguration> config)
        {
            _mapper = mapper;
            _config = config;
        }

        //GET


        //POST


        //PUT
    }
}
