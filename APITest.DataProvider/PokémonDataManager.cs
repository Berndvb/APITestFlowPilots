using APITest.Data;
using APITest.Domain;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APITest.Services
{
    public class PokémonDataManager : IPokémonDataManager
    {
        private IPokémonRepo _repository;
        public PokémonDataManager(IPokémonRepo repo) // ontvangen van repo en vragen aan service wat er moet gebeuren (1à2 lijnen max per functie)
        {
            _repository = repo;
        }

        public async Task<List<Pokémon>> GetAllPokémonAsync()
        {
            var respons = await _repository.GetAllPokémonAsync();

            List<Pokémon> allPokémon = new List<Pokémon>();

            if (respons.StatusCode == System.Net.HttpStatusCode.OK)
            {
                allPokémon = JsonConvert.DeserializeObject<List<Pokémon>>(respons.Content);
                return allPokémon;
            }
            else
            {
                return null;
            }
        }

        public async Task<Pokémon> GetPokémonByIdAsync(int id)
        {
            var respons = await _repository.GetAllPokémonAsync();

            Pokémon selection = new Pokémon();
            if (respons.StatusCode == System.Net.HttpStatusCode.OK)
            {
                selection = JsonConvert.DeserializeObject<List<Pokémon>>(respons.Content).Find(x => x.Id.Equals(id));
                return selection;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Pokémon>> GetSpecificTypesAsync(string type)
        {
            var respons = await _repository.GetAllPokémonAsync();

            List<Pokémon> selection = new List<Pokémon>();
            if (respons.StatusCode == System.Net.HttpStatusCode.OK)
            {
                selection = JsonConvert.DeserializeObject<List<Pokémon>>(respons.Content).FindAll(x => x.Type.Contains(type));
                return selection;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Pokémon>> CreatePokédexAsync(List<Pokémon> pokédex) // !!
        {
            var pokédexJson = JsonConvert.SerializeObject(pokédex);
            //RestRequest request = new RestRequest(pokédexJson, Method.POST);
            //var respons = _repository.Execute(request);
            ////_restClient.SaveChanges

            List<Pokémon> selection = new List<Pokémon>(); // geen statuscode-controle?
            return selection; // wat returnen?
        }
    }
}
