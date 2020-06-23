using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekaWeb.Services
{
    public class AzureService : IAzureService
    {
        private readonly IOptions<BibliotekaConfiguration> _config;

        public AzureService(IOptions<BibliotekaConfiguration> config)
        {
            _config = config;
        }

        public Task<string> AddBlobItem(string blobPath)
        {
            BibliotekaAzureStorageClient azureStorageClient = new BibliotekaAzureStorageClient(_config.Value.StorageConnectionString, _config.Value.StorageContainerName);
            return azureStorageClient.AddBlobItem(blobPath);

        }
        public Task<string> DeleteBlobItem(string blobPath)
        {
            BibliotekaAzureStorageClient azureStorageClient = new BibliotekaAzureStorageClient(_config.Value.StorageConnectionString, _config.Value.StorageContainerName);
            return azureStorageClient.DeleteBlobItem(blobPath);

        }
    }
}
