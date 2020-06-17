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
        HttpClient httpClient = new HttpClient();

        private readonly IMapper _mapper;
        private readonly IOptions<BibliotekaApiConfiguration> _config;

        public PozycjeService(IMapper mapper, IOptions<BibliotekaApiConfiguration> config)
        {
            _mapper = mapper;
            _config = config;
        }

        public async Task<PozycjaViewModel[]> GetPozycjaDetailsAsync(string uzytkownik)
        {
            BibliotekaApiHttpClient serviceClient = new BibliotekaApiHttpClient(_config.Value.Url, httpClient);
            ICollection<Pozycja> dtoItems = await serviceClient.ApiPozycjeGetAsync(uzytkownik);

            return _mapper.Map<ICollection<PozycjaViewModel>>(dtoItems).ToArray();
        }

        public async Task<PozycjaViewModel> GetPozycjaDetailsAsync(int Id)
        {
            BibliotekaApiHttpClient serviceClient = new BibliotekaApiHttpClient(_config.Value.Url, httpClient);
            Pozycja dtoItems = await serviceClient.ApiPozycjeGetAsync(Id);

            return _mapper.Map<PozycjaViewModel>(dtoItems);
        }

        public async Task<PozycjaViewModel> PutPozycjaDetailsAsync(int Id)
        {
            BibliotekaApiHttpClient serviceClient = new BibliotekaApiHttpClient(_config.Value.Url, httpClient);
            //Pozycja dtoItems = await serviceClient.ApiPozycjePutAsync(Id);

            //return _mapper.Map<PozycjaViewModel>(dtoItems);
            return null; //chwilowo aby nie było błedu
        }

        public async Task<PozycjaViewModel> PostPozycjaAsync(Pozycja body)
        {
            BibliotekaApiHttpClient serviceClient = new BibliotekaApiHttpClient(_config.Value.Url, httpClient);
            Pozycja dtoItems = await serviceClient.ApiPozycjePostAsync(body);

            return _mapper.Map<PozycjaViewModel>(dtoItems);


        }

        /*
        public async Task<Guid> AddItemAsync(PozycjaViewModel newItem, AppUser user)
        {
            BibliotekaApiHttpClient todoServiceClient = new BibliotekaApiHttpClient(url, httpClient);

            newItem.OwnerId = user.Id;
            newItem.IsDone = false;
            newItem.DueAt = DateTimeOffset.Now.AddDays(3);
            Guid returnValue = await todoServiceClient.PostAsync(_mapper.Map<ToDoItemDTO>(newItem));

            return returnValue;
        }


        public async Task<PozycjaViewModel[]> GetIncompleteItemsAsync(AppUser user)
        {
            BibliotekaApiHttpClient todoServiceClient = new BibliotekaApiHttpClient(url, httpClient);
            ICollection<ToDoItemDTO> dtoItems = await todoServiceClient.GetAsync(user.Id);

            ICollection<PozycjaViewModel> returnValue = _mapper.Map<ICollection<PozycjaViewModel>>(dtoItems);

            return returnValue.ToArray();
        }

        public async Task<bool> MarkDoneAsync(PozycjaViewModel item, AppUser user)
        {
            BibliotekaApiHttpClient todoServiceClient = new BibliotekaApiHttpClient(url, httpClient);

            item.OwnerId = user.Id;
            item.IsDone = true;

            await todoServiceClient.PutAsync(item.Id, _mapper.Map<ToDoItemDTO>(item));
            return true;

        }
        */
    }
}
