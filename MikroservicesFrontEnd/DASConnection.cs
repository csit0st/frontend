using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace MikroservicesFrontEnd
{
    class DASConnection
    {

        public static async Task<string> GetData()
        {
            HttpClient client = new HttpClient();
            
            Uri request = new Uri("http://www.contoso.com");

            HttpResponseMessage response = new HttpResponseMessage();
            string responseString = "";

            try
            {
                response = await client.GetAsync(request);
                response.EnsureSuccessStatusCode();
                responseString = await response.Content.ReadAsStringAsync();
            } catch(Exception ex)
            {
                responseString = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }


            return responseString;
        }

        public void SendData()
        {

        }

    }
}
