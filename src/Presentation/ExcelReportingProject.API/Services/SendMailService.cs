using Application.Features.Queries.Order.GetOrderGroupBy;
using Application.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sendinblue.Api;
using Sendinblue.Api.Business;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public class SendMailService : ISendMailService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SendMailService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public static string BuildEmailContent(List<SegmentData> segmentsData)
        {
            StringBuilder contentBuilder = new StringBuilder();

            // Tablo başlığı
            contentBuilder.AppendLine("<table>");
            contentBuilder.AppendLine("<tr>");
            contentBuilder.AppendLine("<th>Region</th>");
            contentBuilder.AppendLine("<th>Product Count</th>");
            contentBuilder.AppendLine("<th>Units Sold Sum</th>");
            contentBuilder.AppendLine("<th>Discounts</th>");
            contentBuilder.AppendLine("<th>Profit</th>");
            contentBuilder.AppendLine("</tr>");

            // Veri satırları
            foreach (SegmentData segmentData in segmentsData)
            {
                contentBuilder.AppendLine("<tr>");
                contentBuilder.AppendLine("<td>" + segmentData.ResGroupType + "</td>");
                contentBuilder.AppendLine("<td>" + segmentData.ProductCount + "</td>");
                contentBuilder.AppendLine("<td>" + segmentData.UnitsSoldSum + "</td>");
                contentBuilder.AppendLine("<td>" + segmentData.Discounts + "</td>");
                contentBuilder.AppendLine("<td>" + segmentData.Profit + "</td>");
                contentBuilder.AppendLine("</tr>");
            }

            contentBuilder.AppendLine("</table>");

            return contentBuilder.ToString();
        }
        public async  Task SendMail(List<SegmentData> segment)
        {
            // Veri listesi
            //    List<SegmentData> segmentsData = new List<SegmentData>()
            //{
            //    new SegmentData { ResGroupType = "Canada", ProductCount = 35, UnitsSoldSum = 62291, Discounts = 379497.22, Profit = 803671.78 },
            //    new SegmentData { ResGroupType = "France", ProductCount = 35, UnitsSoldSum = 51326, Discounts = 448087.83, Profit = 811332.17 },
            //    new SegmentData { ResGroupType = "Mexico", ProductCount = 35, UnitsSoldSum = 49305, Discounts = 396479.74, Profit = 592670.26 },
            //    new SegmentData { ResGroupType = "United States of America", ProductCount = 35, UnitsSoldSum = 47480, Discounts = 518937.17, Profit = 552570.83 },
            //    new SegmentData { ResGroupType = "Germany", ProductCount = 35, UnitsSoldSum = 54272, Discounts = 402529.53, Profit = 1118219.47 }
            //};

            List<SegmentData> segmentsData = new List<SegmentData>();
            foreach (var i in segment)
            {
                segmentsData.Add(i);
            }
            // E-posta içeriği oluşturma
            var messageContent = BuildEmailContent(segmentsData);



            var apiKey = "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";
            var url = "https://api.brevo.com/v3/smtp/email";

            var client = new HttpClient();

            // Header'ları ayarla
            client.DefaultRequestHeaders.Add("accept", "application/json");
            client.DefaultRequestHeaders.Add("api-key", apiKey);

            // İstek verilerini oluştur
            var requestData = new
            {
                sender = new { email = "nihadsoltanov@hotmail.com" },
                to = new[] { new { email = "nsoltanov2003@gmail.com" } },
                replyTo = new { email = "nihadsoltanov@hotmail.com" },
                textContent = messageContent,
                subject = "Excel Report",
                tags = new[] { "myFirstTransactional" }
            };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // POST isteğini gönder ve yanıtı al
            var response = await client.PostAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                // Başarılı yanıt
                Console.WriteLine("E-posta gönderme başarılı!");
                Console.WriteLine("Yanıt: " + responseContent);
            }
            else
            {
                // Hata yanıtı
                Console.WriteLine("E-posta gönderme hatası!");
                Console.WriteLine("Hata Kodu: " + response.StatusCode);
                Console.WriteLine("Hata Yanıtı: " + responseContent);
            }




        }
            //}





        }


    }


            