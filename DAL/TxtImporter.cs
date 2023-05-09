using DAL.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
    public class TxtImporter : IImporter
    {
        public IEnumerable<Entrant> Import(string filePath)
        {
            var entrants = new List<Entrant>();

            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("Surname:"))
                    {
                        var entrant = new Entrant();
                        entrant.TestResults = new Dictionary<string, int>();
                        entrant.Specialities = new List<string>();

                        entrant.Surname = Regex.Match(line, @"^Surname: (.+)$").Groups[1].Value;
                        entrant.Name = Regex.Match(reader.ReadLine(), @"^Name: (.+)$").Groups[1].Value;
                        entrant.Patronymic = Regex.Match(reader.ReadLine(), @"^Patronymic: (.+)$").Groups[1].Value;
                        entrant.StudyForm = (StudyForm)Enum.Parse(typeof(StudyForm), Regex.Match(reader.ReadLine(), @"^StudyForm: (.+)$").Groups[1].Value);
                        entrant.StudyLevel = (StudyLevel)Enum.Parse(typeof(StudyLevel), Regex.Match(reader.ReadLine(), @"^StudyLevel: (.+)$").Groups[1].Value);

                        line = reader.ReadLine();
                        while (line != null && line != "Specialities:")
                        {
                            var match = Regex.Match(line, @"^(.+): (\d+)$");
                            if (match.Success)
                            {
                                entrant.TestResults[match.Groups[1].Value] = int.Parse(match.Groups[2].Value);
                            }
                            line = reader.ReadLine();
                        }

                        while ((line = reader.ReadLine()) != null && line != "")
                        {
                            entrant.Specialities.Add(line);
                        }

                        entrants.Add(entrant);
                    }
                }
            }

            return entrants;
        }
    }
}
