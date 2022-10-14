using Core.Utilities.Helpers.GuidHelpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelpers
{
    public class FileHelper : IFileHelper
    {

        public string GetFileName()
        {
            string fileName = new GuidHelper().CreateGuid();
            return fileName;
        }

        public void SaveWithGuid(IFormFile file,string path)
        {
            if (file != null)
            {
                string fileName = new GuidHelper().CreateGuid();
                var extension = Path.GetExtension(path);
                using (FileStream fileStream = System.IO.File.Create(path + GetFileName() + extension))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }
            
        }
    }
}
