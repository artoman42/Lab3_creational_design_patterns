using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BLL
{
    public class XmlExporter : IExporter
    {
        public void Export(List<Entrant> entrants, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Entrant>));
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(stream, entrants);
            }
        }
    }
}
