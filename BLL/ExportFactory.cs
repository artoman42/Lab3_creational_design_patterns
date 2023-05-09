using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ExportFactory 
    {
        public IExporter Create(string extension)
        {
            switch (extension)
            {
                case ".txt":
                    return new TxtExporter();
                    break;
                case ".xml":
                    return new XmlExporter();
                    break;
                case ".json":
                    return new JsonExporter();
                    break;
                default:
                    throw new Exception($"Uknnown Type{extension}");
                    break;
            }
        }
    }
}
