//using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
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

        public async Task<string> AddBlobItem(string base64EncodedString)
        {
            string blobName = new Guid().ToString();
            var base64Stream = StreamExtensions.ConvertFromBase64(base64EncodedString);

            if (CloudStorageAccount.TryParse(_storageConnectionString, out CloudStorageAccount storageAccount))
                {
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer container = blobClient.GetContainerReference(_storageContainerName);
                    await container.CreateIfNotExistsAsync();
                    await container.SetPermissionsAsync(new BlobContainerPermissions()
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob
                    });


                    var blob = container.GetBlockBlobReference(blobName);
                    //await blob.UploadFromFileAsync((blobPath));
                    await blob.UploadFromStreamAsync(base64Stream); 
                    return blob.Uri.ToString();
                }
            //}
            return "";
        }

        public async Task<string> DeleteBlobItem(string blobName)
        {
            if (CloudStorageAccount.TryParse(_storageConnectionString, out CloudStorageAccount storageAccount))
            {
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(_storageContainerName);
                var blob = container.GetBlobReference(blobName);
                await blob.DeleteIfExistsAsync();
                return blob.Uri.ToString();
            }
            return "";
        }
       
    }
}
