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

        #region Variables
        private static Entry currentT;
        private static Entry currentP;
        private static List<Entry> todayT;
        private static List<Entry> todayP;

        private static Entry yesterdayMidT;
        private static Entry yesterdayMidP;
        private static List<Entry> yesterdayT;
        private static List<Entry> yesterdayP;

        private static Entry lastweekMidT;
        private static Entry lastweekMidP;
        private static List<Entry> lastweekT;
        private static List<Entry> lastweekP;
        #endregion

        public static void FetchAllData()
        {
            DASConnection.GetData("http://192.168.178.21/gfh.html", EntryType.TODAY, EntryStyle.TEMPERATURE);
            DASConnection.GetData("http://192.168.178.21/CURRENT/", EntryType.CURRENT, EntryStyle.TEMPERATURE);
            DASConnection.GetData("http://192.168.178.21/CURRENT/", EntryType.YESTERDAY, EntryStyle.TEMPERATURE);
            DASConnection.GetData("http://192.168.178.21/CURRENT/", EntryType.LASTWEEK, EntryStyle.TEMPERATURE);
            DASConnection.GetData("http://192.168.178.21/CURRENT/", EntryType.YESTERDAY, EntryStyle.TEMPERATUREMID);
            DASConnection.GetData("http://192.168.178.21/CURRENT/", EntryType.LASTWEEK, EntryStyle.TEMPERATUREMID);

            DASConnection.GetData("http://192.168.178.21/gfh.html", EntryType.TODAY, EntryStyle.PRESSURE);
            DASConnection.GetData("http://192.168.178.21/CURRENT/", EntryType.CURRENT, EntryStyle.PRESSURE);
            DASConnection.GetData("http://192.168.178.21/CURRENT/", EntryType.YESTERDAY, EntryStyle.PRESSURE);
            DASConnection.GetData("http://192.168.178.21/CURRENT/", EntryType.LASTWEEK, EntryStyle.PRESSURE);
            DASConnection.GetData("http://192.168.178.21/CURRENT/", EntryType.YESTERDAY, EntryStyle.PRESSUREMID);
            DASConnection.GetData("http://192.168.178.21/CURRENT/", EntryType.LASTWEEK, EntryStyle.PRESSUREMID);
        }

        public static void UpdateData(EntryStyle style, EntryType type, string json)
        {
            switch(type)
            {
                case EntryType.CURRENT:
                    if(style == EntryStyle.TEMPERATURE)
                    {
                        currentT = JsonConvert.DeserializeObject<Entry>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm" });
                    } else if (style == EntryStyle.PRESSURE)
                    {
                        currentP = JsonConvert.DeserializeObject<Entry>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm" });
                    }
                    break;
                case EntryType.TODAY:
                    if(style == EntryStyle.TEMPERATURE)
                    {
                        todayT = JsonConvert.DeserializeObject<List<Entry>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm" });
                    }
                    else if(style == EntryStyle.PRESSURE)
                    {
                        todayP = JsonConvert.DeserializeObject<List<Entry>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm" });
                    }
                    break;
                case EntryType.YESTERDAY:
                    if (style == EntryStyle.TEMPERATURE)
                    {
                        yesterdayT = JsonConvert.DeserializeObject<List<Entry>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm" });
                    }
                    else if (style == EntryStyle.PRESSURE)
                    {
                        yesterdayP = JsonConvert.DeserializeObject<List<Entry>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm" });
                    } else if (style == EntryStyle.TEMPERATUREMID)
                    {
                        yesterdayMidT = JsonConvert.DeserializeObject<Entry>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm" });
                    }
                    else if(style == EntryStyle.PRESSUREMID)
                    {
                        yesterdayMidP = JsonConvert.DeserializeObject<Entry>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm" });
                    }
                    break;
                case EntryType.LASTWEEK:
                    if (style == EntryStyle.TEMPERATURE)
                    {
                        lastweekT = JsonConvert.DeserializeObject<List<Entry>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm" });
                    }
                    else if(style == EntryStyle.PRESSURE)
                    {
                        lastweekP = JsonConvert.DeserializeObject<List<Entry>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm" });
                    } else if (style == EntryStyle.TEMPERATUREMID)
                    {
                        lastweekMidT = JsonConvert.DeserializeObject<Entry>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm" });
                    }
                    else if (style == EntryStyle.PRESSUREMID)
                    {
                        lastweekMidP = JsonConvert.DeserializeObject<Entry>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm" });
                    }
                    break;
                default:
                    return;
            }
        }
        
        #region GETS
        public static List<Entry> GetTemperatureDataOfToday()
        {
            return todayT;
        }

        public static List<Entry> GetTemperatureDataOfYesterday()
        {
            return yesterdayT;
        }

        public static List<Entry> GetTemperatureDataOfLastWeek()
        {
            return lastweekT;
        }

        public static List<Entry> GetPressureDataOfToday()
        {
            return todayP;
        }

        public static List<Entry> GetPressureDataOfYesterday()
        {
            return yesterdayP;
        }

        public static List<Entry> GetPressureDataOfLastWeek()
        {
            return lastweekP;
        }

        public static Entry GetCurrentTemperature()
        {
            return currentT;
        }

        public static Entry GetCurrentPressure()
        {
            return currentP;
        }

        public static Entry GetTemperatureMidYesterday()
        {
            return yesterdayMidT;
        }

        public static Entry GetPressureMidYesterday()
        {
            return yesterdayMidP;
        }

        public static Entry GetTemperatureMidLastweek()
        {
            return lastweekMidT;
        }

        public static Entry GetPressureMidLastweek()
        {
            return lastweekMidP;
        }

        #endregion
    }
}