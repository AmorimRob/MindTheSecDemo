using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using MindTheSecDemo.Models;
using MindTheSecDemo.Services.Responses;
using Newtonsoft.Json;

namespace MindTheSecDemo.Services
{
    public class PokemonService : IPokemonService
    {
        public async Task<IEnumerable<Pokemon>> Todos()
        {
            try
            {
                //var httpClient = new HttpClient();
                //var response = await httpClient.GetStringAsync("https://pokeapi.co/api/v2/pokemon");

                var response = await ("https://pokeapi.co/" + "api/v2/pokemon")
                                .GetStringAsync();

                var result = JsonConvert.DeserializeObject<PokemonServiceResponse>(response);

                return result.Results;
            }
            catch (FlurlHttpException e)
            {
                if (e.Call.HttpStatus == System.Net.HttpStatusCode.BadRequest)
                    throw new Exception(await e.Call.Response.Content.ReadAsStringAsync());
                else if (e.Call.Completed == false)
                    throw new FlurlHttpException(e.Call, "Sua conexão com o servidor não é segura.", null);
                else
                    throw;
            }
        }
    }
}
