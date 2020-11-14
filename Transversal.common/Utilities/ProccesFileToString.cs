using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Transversal.common.Utilities
{
   public static class ProccesFileToString
    {
        public static List<string> FileToString(IFormFile file)
        {
            Stream filestream = file.OpenReadStream();
            StreamReader streamReader = new StreamReader(filestream);

            string fileRead = streamReader.ReadToEnd();
            List<string> list = fileRead.Split(new char[] { '\n' }).ToList();
            return list;
        }
    }
}
