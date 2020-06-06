using AutoMapper;
using BibliotekaApi.Models;
using BibliotekaWeb;
using BibliotekaWeb.HttpClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication.Services
{
    public class PozycjeService : IPozycjeService
    {
        //string url = "https://localhost:44342/";
        HttpClient httpClient = new HttpClient();

        private readonly IMapper _mapper;
        private readonly IOptions<BibliotekaApiConfiguration> _config;

        public PozycjeService(IMapper mapper, IOptions<BibliotekaApiConfiguration> config)
        {
            _mapper = mapper;
            _config = config;
        }

        public async Task<PozycjaViewModel> GetPozycjaDetailsAsync(int Id)
        {
            BibliotekaApiHttpClient todoServiceClient = new BibliotekaApiHttpClient(_config.Value.Url, httpClient);
            Pozycja dtoItems = await todoServiceClient.Pozycje3Async(Id);

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
