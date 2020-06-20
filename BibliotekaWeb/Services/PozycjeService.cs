using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BibliotekaWeb;
using BibliotekaWeb.Models;
using BibliotekaWeb.Services;
using BibliotekaWeb.HttpClients;

namespace BibliotekaWeb.Services
{
    public class PozycjeService : IPozycjeService
    {
        readonly HttpClient httpClient = new HttpClient();

        private readonly IMapper _mapper;
        private readonly IOptions<BibliotekaConfiguration> _config;

        public PozycjeService(IMapper mapper, IOptions<BibliotekaConfiguration> config)
        {
            _mapper = mapper;
            _config = config;
        }

        public async Task<PozycjaViewModel[]> GetPozycjaAsync(string uzytkownik)
        {
            BibliotekaApiHttpClient serviceClient = new BibliotekaApiHttpClient(_config.Value.BibliotekaApiUrl, httpClient);
            ICollection<Pozycja> dtoItems = await serviceClient.ApiPozycjeGetAsync(uzytkownik);

            return _mapper.Map<ICollection<PozycjaViewModel>>(dtoItems).ToArray();
        }

        public async Task<PozycjaViewModel> GetPozycjaAsync(int Id)
        {
            BibliotekaApiHttpClient serviceClient = new BibliotekaApiHttpClient(_config.Value.BibliotekaApiUrl, httpClient);
            Pozycja dtoItems = await serviceClient.ApiPozycjeGetAsync(Id);

            return _mapper.Map<PozycjaViewModel>(dtoItems);
        }

        public async Task PutPozycjaAsync(int Id, PozycjaViewModel pozycjaViewModel)
        {
            var pozycja = _mapper.Map<Pozycja>(pozycjaViewModel);
            BibliotekaApiHttpClient serviceClient = new BibliotekaApiHttpClient(_config.Value.BibliotekaApiUrl, httpClient);
            await serviceClient.ApiPozycjePutAsync(Id, pozycja);
        }

        public async Task<PozycjaViewModel> PostPozycjaAsync(Pozycja body)
        {
            BibliotekaApiHttpClient serviceClient = new BibliotekaApiHttpClient(_config.Value.BibliotekaApiUrl, httpClient);
            Pozycja dtoItems = await serviceClient.ApiPozycjePostAsync(body);

            return _mapper.Map<PozycjaViewModel>(dtoItems);


        }

        public async Task<PozycjaViewModel> DeletePozycjaAsync(int id)
        {
            BibliotekaApiHttpClient serviceClient = new BibliotekaApiHttpClient(_config.Value.BibliotekaApiUrl, httpClient);
            Pozycja dtoItems = await serviceClient.ApiPozycjeDeleteAsync(id);

            return _mapper.Map<PozycjaViewModel>(dtoItems);


        }
    }
}
