using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using Newtonsoft.Json.Converters;

namespace MikroservicesFrontEnd
{
    class DASConnection
    {

        public static async void GetAndWriteData(String uri)
        {
            HttpClient client = new HttpClient();
            
            Uri request = new Uri(uri);

            HttpResponseMessage response = new HttpResponseMessage();
            string responseString = "";

            try
            {
                response = await client.GetAsync(request);
                response.EnsureSuccessStatusCode();
                string json = await @response.Content.ReadAsStringAsync();
                Debug.WriteLine(json);
                json.Replace("\\", "");
                EntryManager.UpdateData(EntryType.TODAY, json);
            } catch(Exception ex)
            {
                responseString = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }
        }

        public static List<Entry> TestDataDay()
        {
            string json = @"[{""Time"":""11.12.2018 00:00"", ""Value"": ""15.00""},
                            {""Time"":""11.12.2018 03:00"", ""Value"": ""17.00""},
                            {""Time"":""11.12.2018 06:00"", ""Value"": ""16.00""},
                            {""Time"":""11.12.2018 09:00"", ""Value"": ""13.00""},
                            {""Time"":""11.12.2018 12:00"", ""Value"": ""17.00""},
                            {""Time"":""11.12.2018 15:00"", ""Value"": ""24.00""},
                            {""Time"":""11.12.2018 18:00"", ""Value"": ""13.00""},
                            {""Time"":""11.12.2018 21:00"", ""Value"": ""17.00""},
                            {""Time"":""12.12.2018 00:00"", ""Value"": ""24.00""}
                            ]";

            List<Entry> entry = JsonConvert.DeserializeObject<List<Entry>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm" });

            return entry;

        }

        public static List<Entry> TestDataWeek()
        {
            string json = @"[
                            {""Time"":""10.12.2018"", ""Value"": ""15.00""},
                            {""Time"":""11.12.2018"", ""Value"": ""17.00""},
                            {""Time"":""12.12.2018"", ""Value"": ""16.00""},
                            {""Time"":""13.12.2018"", ""Value"": ""13.00""},
                            {""Time"":""14.12.2018"", ""Value"": ""17.00""},
                            {""Time"":""15.12.2018"", ""Value"": ""24.00""},
                            {""Time"":""16.12.2018"", ""Value"": ""13.00""}
                            ]";

            List<Entry> entry = JsonConvert.DeserializeObject<List<Entry>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" });

            return entry;

        }

        public static Entry TestDataCurrent()
        {
            string json = @"{ ""Time"":""11.12.2018 12:53"", ""Value"": ""15.00""}";

            Entry entry = JsonConvert.DeserializeObject<Entry>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm" });

            return entry;
        }

    }
}
