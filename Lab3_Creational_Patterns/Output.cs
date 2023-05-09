using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace UIL
{
    public class Output : IOutput
    {
        public void WriteToConsole(IEnumerable<Entrant> entrants)
        {
            foreach(var entrant in entrants)
            {
                Console.WriteLine(entrant.ToString());  
            }
        }
    }
}
