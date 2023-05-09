using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class ImporterFactory 
    {
       
        public IImporter Create(string extension)
        {
            
            switch (extension)
            {
                case ".txt":
                    return new TxtImporter();
                    break;
                case ".xml":
                    return new XmlImporter();
                case ".json":
                    return new JsonImporter();
                default:
                    throw new Exception($"Uknown type: {extension}");
                    break;
            }
            
        }
        
    }
}
