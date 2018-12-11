using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Diagnostics;
using System.IO;
using Windows.UI.Core;

namespace MikroservicesFrontEnd
{
    public class AASConnection
    {

        public static void StartConnection()
        {
            StartClient();
        }

        static string EncryptString(string input)
        {
            SHA256 sha = SHA256.Create();
            var result = new StringBuilder();
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte x in bytes)
            {
                result.Append(x.ToString("x2"));
            }
            return result.ToString();
        }

        static string PortNumber = "1337";

        private static async void StartClient()
        {
            try
            {
                using (var streamSocket = new Windows.Networking.Sockets.StreamSocket())
                {
                    var hostName = new Windows.Networking.HostName("localhost");

                    Debug.WriteLine("client is trying to connect...");

                    await streamSocket.ConnectAsync(hostName, PortNumber);

                    Debug.WriteLine("client connected");
                    
                    string request = "CLIENT";
                    using (Stream outputStream = streamSocket.OutputStream.AsStreamForWrite())
                    {
                        using (var streamWriter = new StreamWriter(outputStream))
                        {
                            await streamWriter.WriteLineAsync(request);
                            await streamWriter.FlushAsync();
                        }
                    }

                    Debug.WriteLine(string.Format("client sent the request: \"{0}\"", request));
                    
                    string response;
                    using (Stream inputStream = streamSocket.InputStream.AsStreamForRead())
                    {
                        using (StreamReader streamReader = new StreamReader(inputStream))
                        {
                            response = await streamReader.ReadLineAsync();
                        }
                    }

                    Debug.WriteLine(string.Format("client received the response: \"{0}\" ", response));
                }

                Debug.WriteLine("client closed its socket");
            }
            catch (Exception ex)
            {
                Windows.Networking.Sockets.SocketErrorStatus webErrorStatus = Windows.Networking.Sockets.SocketError.GetStatus(ex.GetBaseException().HResult);
                Debug.WriteLine(webErrorStatus.ToString() != "Unknown" ? webErrorStatus.ToString() : ex.Message);
            }
        }

    }
}
