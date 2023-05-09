using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIL
{
    public interface IEntrantsInput
    {
        public List<Entrant> Input(int amount = 3);
    }
}
