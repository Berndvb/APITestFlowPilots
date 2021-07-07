using APITest.Domain;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Data
{
    public class PokémonRepo : IPokémonRepo
    {
        const string APIURL = "https://raw.githubusercontent.com/fanzeyi/pokemon.json/master/pokedex.json"; 
        internal RestClient _restClient = null;

        public PokémonRepo()
        {
            _restClient = new RestClient(APIURL);
        }
        public async Task<IRestResponse> GetAllPokémonAsync()
        {
            RestRequest request = new RestRequest(Method.GET);
            var respons = await _restClient.ExecuteAsync(request);
            return respons;
        }
    }
}
