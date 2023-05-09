using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.enums;

namespace UIL
{
    public class EntrantsInput : IEntrantsInput
    {
        public List<Entrant> Input(int amount=3)
        {
            List<Entrant> entrants = new List<Entrant>();
            for(int i= 0; i < amount; i++) {
                Console.WriteLine("Enter Surname:");
                string Surname = Console.ReadLine();
                Console.WriteLine("Enter Name:");
                string Name = Console.ReadLine();
                Console.WriteLine("Enter Patronymic:");
                string Patronymic = Console.ReadLine();
                Console.WriteLine("Enter Amount of Specialities");
                int specAmounts;
                while (!int.TryParse(Console.ReadLine(),out specAmounts)){
                    Console.WriteLine("Invalid input. Please enter an integer.");
                }
                List<string> specialities = new List<string>();
                for(int j=0; j < specAmounts; j++)
                {
                    Console.WriteLine("Enter speciality name :");
                    specialities.Add(Console.ReadLine());
                }
                Dictionary<string, int> TestResults = new Dictionary<string, int>();
                Console.WriteLine("Enter Test Results :");
                for(int j=0;j<3; j++)
                {
                    Console.WriteLine("Enter Test Name : ");
                    string s = Console.ReadLine();
                    Console.WriteLine("Enter Test Result : ");
                    int res;
                    while (!int.TryParse(Console.ReadLine(), out res))
                    {
                        Console.WriteLine("Invalid input. Please enter an integer.");
                    }
                    TestResults.Add(s, res);
                }
                Console.WriteLine("Enter SudyForm :");
                StudyForm studyForm;
                while (!Enum.TryParse(Console.ReadLine(), out studyForm))
                {
                    Console.WriteLine("Invalid input. Please enter an StudyForm.");
                }
                Console.WriteLine("Enter StudyLevel :");
                StudyLevel studyLevel;
                while (!Enum.TryParse(Console.ReadLine(), out studyLevel))
                {
                    Console.WriteLine("Invalid input. Please enter an StudyLevel.");
                }
                entrants.Add(
                    new Entrant()
                    {
                        Name = Name,
                        Surname = Surname,
                        Patronymic = Patronymic,
                        TestResults = TestResults,
                        Specialities = specialities,
                        StudyForm = studyForm,
                        StudyLevel = studyLevel
                    }) ;
            }
            return entrants;
        }
    }
}
