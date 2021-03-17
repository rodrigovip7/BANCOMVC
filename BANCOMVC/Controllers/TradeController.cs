using BANCOMVC.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BANCOMVC.Controllers
{
    public class TradeController : Controller
    {

        public async Task<IActionResult> IndexAsync(List<Trade> portfolio)
        {
            //valores para teste
            Trade Trade1 = new Trade { Value = 2000000, ClientSector = "Private" };
            Trade Trade2 = new Trade { Value = 400000, ClientSector = "Public" };
            Trade Trade3 = new Trade { Value = 500000, ClientSector = "Public" };
            Trade Trade4 = new Trade { Value = 3000000, ClientSector = "Public" };

            portfolio.Add(Trade1);
            portfolio.Add(Trade2);
            portfolio.Add(Trade3);
            portfolio.Add(Trade4);


            //chamada do serviço
            List<string> tradeCategories = new List<string>();
            string url = "https://localhost:44388/api/v1/Trade/GetTradeCategories/";


            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                var json = JsonConvert.SerializeObject(portfolio);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    request.Content = stringContent;

                    using (var response = await client
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false)
                        )
                    {
                        response.EnsureSuccessStatusCode();

                        // Deserialization JSON
                        var jsonret = response.Content.ReadAsStringAsync().Result;
                        var ret = JsonConvert.DeserializeObject<dynamic>(jsonret);

                        foreach (var item in ret)
                            tradeCategories.Add(item.ToString());
                    }
                }
            }



            ViewBag.tradeCategories = tradeCategories;

            return View();
        }
    }
}
