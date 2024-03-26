using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DiscordWebhookSender
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string webhookUrl = "link webhook kamu masukkan disini";

            string messageContent = new WebClient().DownloadString("https://ipapi.unreliablecode.net/");

            var payload = new
            {
                content = messageContent
            };
            string payloadJson = JsonConvert.SerializeObject(payload);

            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(payloadJson, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(webhookUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Webhook sent successfully!");
                }
                else
                {
                    Console.WriteLine("Error sending webhook. Status code: " + response.StatusCode);
                }
            }
        }
    }
}
