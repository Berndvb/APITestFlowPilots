using APITest.Data;
using APITest.Domain;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITest.Services
{
    public class PokémonDataManager : IPokémonDataManager
    {
        private readonly IPokémonRepo _repository;
<<<<<<< HEAD
        private readonly ApplicationDbContext _dbContext;
       /* private List<Pokémon> _allPokémon;*/ //cach: opslaan + validatie (-> lazy loading, koppelen aan method; dus enkel wanneer gevraagd)
        public PokémonDataManager(IPokémonRepo repo, ApplicationDbContext dbContext) // ontvangen van repo en vragen aan service wat er moet gebeuren (1à2 lijnen max per functie)
=======
        private List<Pokémon> _allPokémon; //cach: opslaan + validatie (-> lazy loading, koppelen aan method; dus enkel wanneer gevraagd)
        public PokémonDataManager(IPokémonRepo repo) // ontvangen van repo en vragen aan service wat er moet gebeuren (1à2 lijnen max per functie)
>>>>>>> parent of a6f9865 (chris2)
        {
            _repository = repo;
        }

        public async Task<List<Pokémon>> GetAllPokémonAsync()
        {
<<<<<<< HEAD
            var allPokémon = new List<Pokémon>();
            if (_dbContext.Pokémons.Any() == false)
=======
            if (_allPokémon == null)
>>>>>>> parent of a6f9865 (chris2)
            {
                var respons = await _repository.GetAllPokémonAsync();

                if (respons.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var PokémonJson = JsonConvert.DeserializeObject<List<DummyPokémon>>(respons.Content);
                    foreach (var pokémon in PokémonJson)
                    {
                        var newPokémon = new Pokémon
                        {
                            Name = pokémon.Name,
                            Stats = pokémon.Stats,
                            Type = new List<PokémonType>()
                        };

                        foreach (var item in pokémon.Type)
                        {
                            if (Enum.TryParse(item, out EPokémonType myStatus))
                            {
                                newPokémon.Type.Add(new PokémonType() { Type = myStatus });
                            }
                            else
                            {
                                throw new Exception($"{item} String -> Enum converter");
                            }
                        }
                        allPokémon.Add(newPokémon);
                        await _dbContext.AddAsync(newPokémon);
                        await _dbContext.SaveChangesAsync();
                    }
                }
            }
            else
            {
                allPokémon = await _dbContext.Pokémons.ToListAsync();
            }
            return allPokémon;
        }

        public async Task<Pokémon> GetPokémonByIdAsync(int id)
        {
            var allPokémon = await GetAllPokémonAsync();
            var test = allPokémon;
            var test2 = allPokémon.FirstOrDefault(x => x.Id.Equals(id));
            return allPokémon.FirstOrDefault(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<Pokémon>> GetSpecificTypesAsync(string type)
        {
            var allPokémon = await GetAllPokémonAsync();
            return allPokémon.FindAll(x => x.Type.ToString().Contains(type));
        }

<<<<<<< HEAD
        public async void InsertIntoDB()
        {
            foreach (var pokémon in await GetAllPokémonAsync())
            {
                await _dbContext.AddAsync(pokémon);
            }

            await _dbContext.SaveChangesAsync();
=======
        //________________________________________________________________________________________________________________________

        public async Task<IEnumerable<Pokémon>> CreatePokédexAsync(List<Pokémon> pokédex) // !!
        {
            var pokédexJson = JsonConvert.SerializeObject(pokédex);
            //RestRequest request = new RestRequest(pokédexJson, Method.POST);
            //var respons = _repository.Execute(request);
            ////_restClient.SaveChanges

            List<Pokémon> selection = new List<Pokémon>(); // geen statuscode-controle?
            return selection; // wat returnen?
>>>>>>> parent of a6f9865 (chris2)
        }
    }
}
