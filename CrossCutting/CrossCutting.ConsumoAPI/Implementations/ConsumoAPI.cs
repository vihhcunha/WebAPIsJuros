using CrossCutting.ConsumoAPI.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.ConsumoAPI.Implementations
{
    public class ConsumoAPI<T> : IConsumoAPI<T>
    {
        public async Task<T> Get(string url)
        {
            using var httpRequest = new HttpClient();

            var httpResponse = await httpRequest.GetAsync(url);

            if (!httpResponse.IsSuccessStatusCode) 
                throw new Exception("Algo deu errado!");

            return JsonConvert.DeserializeObject<T>(await httpResponse.Content.ReadAsStringAsync());
        }
    }
}
