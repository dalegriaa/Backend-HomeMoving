using Microsoft.AspNetCore.Http;
using Transversal.Common;

namespace Application.Interface
{
   public  interface IDataProcessApplication
    {
        Response<string> InsertDataProcessFile(IFormFile file, int id);

    }
}
