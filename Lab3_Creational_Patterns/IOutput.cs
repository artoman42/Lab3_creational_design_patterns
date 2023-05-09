using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIL
{
    public interface IOutput
    {
        public void WriteToConsole(IEnumerable<Entrant> entrants);
    }
}
