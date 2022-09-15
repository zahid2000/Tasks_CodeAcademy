using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PYP_Day16_Task.Entities;
using PYP_Day16_Task.Services.Abstract;
using System.Net;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
namespace PYP_Day16_Task.Services.Concrete
{
    public class ClientService : IClientService
    {
        HttpClient client = new HttpClient();
        public async Task<List<VCard>> GetAllAsyncFromUrl(string url)
        {
            List<VCard> cards = new List<VCard>();
            var request = WebRequest.Create("https://randomuser.me/api?results=50");
            request.Method = "GET";

            using (var webResponse = await request.GetResponseAsync())
            {
                using (var webStream = webResponse.GetResponseStream())
                {
                    using (var reader = new StreamReader(webStream))
                    {
                        var data = await reader.ReadToEndAsync();
                        dynamic records = JsonConvert.DeserializeObject(data);
                        foreach (var result in records.results)
                        {
                            cards.Add(new VCard
                            {
                                FirstName = result.name.first,
                                Surname = result.name.last,
                                Email = result.email,
                                Phone = result.phone,
                                Country = result.location.country,
                                City = result.location.city
                            });
                        }
                        return cards;
                    }
                }
            }
        }
    }
}
