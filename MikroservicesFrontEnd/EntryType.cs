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

        TEMPERATURE, PRESSURE, TODAY, YESTERDAY, LASTWEEK, TOMORROW

    }

    public enum EntryStyle
    {
        HOUR, DAY
    }

}
