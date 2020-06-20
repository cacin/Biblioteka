//using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

//https://dotnetcoretutorials.com/2017/06/17/using-azure-blob-storage-net-core/
//https://factorycode.wordpress.com/2019/06/13/upload-files-in-azure-blob-storage-using-asp-net-core-web-api/

namespace BibliotekaWeb.Services
{
    public class BibliotekaAzureStorageClient
    {

        private readonly string _storageConnectionString = "";
        private readonly string _storageContainerName = "";

        public BibliotekaAzureStorageClient(string storageConnectionString, string storageContainerName)
        {
            _storageConnectionString = storageConnectionString;
            _storageContainerName = storageContainerName;
        }

        public async Task<string> AddBlobItem(string blobPath)
        {
            if (System.IO.File.Exists(blobPath))
            {
                string blobName = Path.GetFileName(blobPath);
                if (CloudStorageAccount.TryParse(_storageConnectionString, out CloudStorageAccount storageAccount))
                {
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer container = blobClient.GetContainerReference(_storageContainerName);
                    await container.CreateIfNotExistsAsync();                    

                    var blob = container.GetBlockBlobReference(blobName);
                    await blob.UploadFromFileAsync((blobPath));
                    return blob.Uri.ToString();
                }
            }
            return "";
        }
    }
}
