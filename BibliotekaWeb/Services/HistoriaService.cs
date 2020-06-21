using AutoMapper;
using BibliotekaWeb.HttpClients;
using BibliotekaWeb.Models;
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
        public async Task GetHistoriaAsync(int id)
        {
            BibliotekaApiHttpClient serviceClient = new BibliotekaApiHttpClient(_config.Value.BibliotekaApiUrl, httpClient);
            await serviceClient.ApiHistoriaGetAsync(id);
        }
        //POST
        public async Task PostHistoriaAsync(int id, System.DateTimeOffset dataOd, string osoba)
        {
            BibliotekaApiHttpClient serviceClient = new BibliotekaApiHttpClient(_config.Value.BibliotekaApiUrl, httpClient);
            await serviceClient.ApiHistoriaPostAsync(id, dataOd, osoba);

        }

        //PUT
        public async Task PutHistoriaAsync (int id, System.DateTimeOffset dataDo)
        {
            BibliotekaApiHttpClient serviceClient = new BibliotekaApiHttpClient(_config.Value.BibliotekaApiUrl, httpClient);
            await serviceClient.ApiHistoriaPutAsync(id, dataDo);

        }
    }
}
