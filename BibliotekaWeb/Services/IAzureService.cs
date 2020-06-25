using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekaWeb.Services
{
    public interface IAzureService
    {
        Task<string> AddBlobItem(string blobPath);
        Task DeleteBlobItem(string blobUri);
    }
}
