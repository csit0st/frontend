using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroservicesFrontEnd
{
    public enum EntryType
    {

        TODAY, YESTERDAY, LASTWEEK, TOMORROW, CURRENT

    }

    public enum EntryStyle
    {
        TEMPERATURE, PRESSURE, TEMPERATUREMID, PRESSUREMID
    }

}
