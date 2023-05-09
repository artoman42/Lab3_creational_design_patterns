using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL
{
    public class JsonImporter : IImporter
    {
        public IEnumerable<Entrant> Import(string filePath)
        {
            List<Entrant> entrants = new List<Entrant>();

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            using (StreamReader stream = new StreamReader(filePath))
            {
                string jsonString = stream.ReadToEnd();
                entrants = JsonSerializer.Deserialize<List<Entrant>>(jsonString, options);
            }

            return entrants;
        }
    }
}
