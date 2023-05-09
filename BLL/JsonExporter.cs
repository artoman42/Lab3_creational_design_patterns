using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BLL
{
    public class JsonExporter:IExporter
    {
        public void Export(List<Entrant> entrants, string filePath)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            using (StreamWriter stream = new StreamWriter(filePath))
            {
                string jsonString = JsonSerializer.Serialize(entrants, options);
                stream.Write(jsonString);
            }
        }
    }
}
