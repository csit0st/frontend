using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroservicesFrontEnd
{
    public class Entry
    {

        public Entry(DateTime time, double value)
        {
            this.time = time;
            this.value = value;
        }

        private DateTime time;

        private double value;
        private EntryType type;
        private EntryStyle style;

        public DateTime Time
        {
            get { return time; }
        }

        public double Value
        {
            get { return value; }
        }

        public EntryType EntryType
        {
            get { return type; }
            set { this.type = value; }
        }
        public EntryStyle EntryStyle
        {
            get { return style; }
            set { this.style = value; }
        }

    }
}
