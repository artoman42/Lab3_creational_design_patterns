using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TxtExporter : IExporter
    {
        
            public void Export(List<Entrant> entrants, string filePath)
            {
                using (var writer = new StreamWriter(filePath))
                {
                    foreach (var entrant in entrants)
                    {
                        writer.WriteLine($"Surname: {entrant.Surname}");
                        writer.WriteLine($"Name: {entrant.Name}");
                        writer.WriteLine($"Patronymic: {entrant.Patronymic}");
                        writer.WriteLine($"StudyForm: {entrant.StudyForm}");
                        writer.WriteLine($"StudyLevel: {entrant.StudyLevel}");
                        writer.WriteLine("TestResults:");

                        foreach (var result in entrant.TestResults)
                        {
                            writer.WriteLine($"{result.Key}: {result.Value}");
                        }

                        writer.WriteLine("Specialities:");

                        foreach (var speciality in entrant.Specialities)
                        {
                            writer.WriteLine(speciality);
                        }

                        writer.WriteLine();
                    }
                }
            }
        } 

}
