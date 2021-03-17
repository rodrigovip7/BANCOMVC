using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BANCOMVC.Interface
{
    public class Trade : ITrade
    {
        public double Value { get; set; }
        public string ClientSector { get; set; }
    }
}
