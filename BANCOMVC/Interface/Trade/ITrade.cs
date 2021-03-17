using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BANCOMVC.Interface
{
    interface ITrade
    {
        double Value { get; }
        string ClientSector { get; }
    }
}
