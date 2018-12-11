using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace MikroservicesFrontEnd
{
    public static class EntryManager
    {

        private static List<Entry> today;
        private static List<Entry> yesterday;
        private static List<Entry> lastweek;

        public static void FetchAllData()
        {
            DASConnection.GetAndWriteData("http://localhost/gfh.html");
        }

        public static void UpdateData(EntryType type, string json)
        {
            switch(type)
            {
                case EntryType.TODAY:
                    today = JsonConvert.DeserializeObject<List<Entry>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm" });
                    break;
                case EntryType.YESTERDAY:
                    yesterday = JsonConvert.DeserializeObject<List<Entry>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm" });
                    break;
                case EntryType.LASTWEEK:
                    lastweek = JsonConvert.DeserializeObject<List<Entry>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm" });
                    break;
                default:
                    return;
            }
        }

        public static List<Entry> GetDataOfToday()
        {
            return today;
        }

        public static List<Entry> GetDataOfYesterday()
        {
            return yesterday;
        }

        public static List<Entry> GetDataOfLastWeek()
        {
            return lastweek;
        }

    }
}
