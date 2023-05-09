using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL
{
    public class XmlImporter: IImporter
    {
        public IEnumerable<Entrant> Import(string filePath)
        {
            List<Entrant> entrants = new List<Entrant>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Entrant>));
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                entrants = (List<Entrant>)serializer.Deserialize(stream);
            }

            return entrants;
        }
    }
}
