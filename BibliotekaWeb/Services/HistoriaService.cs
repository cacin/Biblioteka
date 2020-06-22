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
        public async Task<ICollection<HistoriaViewModel>> GetHistoriaListAsync(int id)
        {
            BibliotekaApiHttpClient serviceClient = new BibliotekaApiHttpClient(_config.Value.BibliotekaApiUrl, httpClient);
            ICollection<Historia> dtoItems =  await serviceClient.ApiHistoriaGetAsync(id);
            return _mapper.Map<ICollection<HistoriaViewModel>>(dtoItems).ToArray();

        }

        public async Task<HistoriaViewModel> GetHistoriaAsync(int id)
        {
            BibliotekaApiHttpClient serviceClient = new BibliotekaApiHttpClient(_config.Value.BibliotekaApiUrl, httpClient);
            Pozycja dtoItems = await serviceClient.ApiPozycjeGetAsync(id);

            HistoriaViewModel historiaViewModel = new HistoriaViewModel();
          
             historiaViewModel.Pozycja = _mapper.Map<BibliotekaDb.Entities.Pozycja>(dtoItems);
            return historiaViewModel;
        }

        public async Task<ReturnViewModel> GetReturnAsync(int id)
        {
            BibliotekaApiHttpClient serviceClient = new BibliotekaApiHttpClient(_config.Value.BibliotekaApiUrl, httpClient);
            Pozycja dtoItems = await serviceClient.ApiPozycjeGetAsync(id);

            ReturnViewModel returnViewModel = new ReturnViewModel();

            returnViewModel.Pozycja = _mapper.Map<BibliotekaDb.Entities.Pozycja>(dtoItems);
            return returnViewModel;
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
