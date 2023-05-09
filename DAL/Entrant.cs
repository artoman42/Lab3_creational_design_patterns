using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml;
using System.Xml.Serialization;
using DAL.enums;
namespace DAL
{
    public class Entrant : IXmlSerializable
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public Dictionary<string, int> TestResults { get; set; }
        public List<string> Specialities { get; set; }
        public StudyForm StudyForm { get; set; }
        public StudyLevel StudyLevel { get; set; }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            TestResults = new Dictionary<string, int>();
            Specialities = new List<string>();

            reader.ReadStartElement(); 

            Surname = reader.ReadElementContentAsString(nameof(Surname), "");
            Name = reader.ReadElementContentAsString(nameof(Name), "");
            Patronymic = reader.ReadElementContentAsString(nameof(Patronymic), "");

            reader.ReadStartElement(nameof(TestResults)); 

            while (reader.NodeType == XmlNodeType.Element)
            {
                var key = reader.GetAttribute("key");
                var value = reader.ReadElementContentAsInt(nameof(TestResults), "");
                TestResults.Add(key, value);
            }

            reader.ReadEndElement(); 

            reader.ReadStartElement(nameof(Specialities)); 

            while (reader.NodeType == XmlNodeType.Element)
            {
                var speciality = reader.ReadElementContentAsString(nameof(Specialities), "");
                Specialities.Add(speciality);
            }

            reader.ReadEndElement();

            StudyForm = (StudyForm)Enum.Parse(typeof(StudyForm), reader.ReadElementContentAsString(nameof(StudyForm), ""));
            StudyLevel = (StudyLevel)Enum.Parse(typeof(StudyLevel), reader.ReadElementContentAsString(nameof(StudyLevel), ""));

            reader.ReadEndElement(); 
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString(nameof(Surname), Surname);
            writer.WriteElementString(nameof(Name), Name);
            writer.WriteElementString(nameof(Patronymic), Patronymic);

            writer.WriteStartElement(nameof(TestResults));

            foreach (var kvp in TestResults)
            {
                writer.WriteStartElement(nameof(TestResults));
                writer.WriteAttributeString("key", kvp.Key);
                writer.WriteValue(kvp.Value);
                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            writer.WriteStartElement(nameof(Specialities));

            foreach (var speciality in Specialities)
            {
                writer.WriteElementString(nameof(Specialities), speciality);
            }

            writer.WriteEndElement();

            writer.WriteElementString(nameof(StudyForm), StudyForm.ToString());
            writer.WriteElementString(nameof(StudyLevel), StudyLevel.ToString());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Surname : {Surname} \n");
            sb.Append($"Name:{Name}\n");
            sb.Append($"Patronymic : {Patronymic}\n Specialities \n");
            
            foreach ( var item in Specialities ) {
                sb.Append($"{item}\n");
            }
            sb.Append("Test Results : \n");
            foreach( var item in TestResults )
            {
                sb.AppendLine($"{item.Key} {item.Value}");
            }
            sb.Append($"StudyForm : {StudyForm.ToString()}\n");
            sb.Append($"StudyLevel : {StudyLevel.ToString()}\n");
            return sb.ToString();
        }
    }
}
