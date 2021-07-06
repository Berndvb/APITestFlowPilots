using APITest.Data;
using APITest.Domain;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITest.Services
{
    public class PokémonDataManager : IPokémonDataManager
    {
        private readonly IPokémonRepo _repository;
        private List<Pokémon> _allPokémon; //cach: opslaan + validatie (-> lazy loading, koppelen aan method; dus enkel wanneer gevraagd)
        public PokémonDataManager(IPokémonRepo repo) // ontvangen van repo en vragen aan service wat er moet gebeuren (1à2 lijnen max per functie)
        {
            _repository = repo;
        }

        public async Task<List<Pokémon>> GetAllPokémonAsync()
        {
            if (_allPokémon == null)
            {
                var respons = await _repository.GetAllPokémonAsync();

                if (respons.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    _allPokémon = JsonConvert.DeserializeObject<List<Pokémon>>(respons.Content);
                }
            }
            return _allPokémon;
        }

        public async Task<Pokémon> GetPokémonByIdAsync(int id)
        {
            var allPokémon = await GetAllPokémonAsync();
            return allPokémon.FirstOrDefault(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<Pokémon>> GetSpecificTypesAsync(string type)
        {
            var allPokémon = await GetAllPokémonAsync();
            return allPokémon.FindAll(x => x.Type.ToString().Contains(type));
        }

        //________________________________________________________________________________________________________________________

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
