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
        private readonly ApplicationDbContext _dbContext;
        //private List<Pokémon> _allPokémon;

        public PokémonDataManager(IPokémonRepo repo, ApplicationDbContext dbContext)
        {
            _repository = repo;
            _dbContext = dbContext;
        }
        public async Task<List<Pokémon>> GetAllPokémonAsync()
        {
            var allPokémon = new List<Pokémon>();
            if (_dbContext.Pokémons.Any() == false)
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
                            if (Enum.TryParse(item, out EPokémonType pType))
                            {
                                newPokémon.Type.Add(new PokémonType() { Type = pType });
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
                allPokémon = await _dbContext.Pokémons.Include(x => x.Name).Include(x => x.Stats).Include(x => x.Type).ToListAsync();
            }
            return allPokémon;
        }

        public async Task<Pokémon> GetPokémonByIdAsync(int id)
        {
            var allPokémon = await GetAllPokémonAsync();
            return allPokémon.FirstOrDefault(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<Pokémon>> GetSpecificTypesAsync(string typeInput)
        {
            var selectedPokémon = new List<Pokémon>();
            foreach (var pokémon in await GetAllPokémonAsync())
            {
                foreach (var type in pokémon.Type)
                {
                    if (type.Type.ToString().Equals(typeInput))
                    {
                        selectedPokémon.Add(pokémon);
                    }
                }
            }
            return selectedPokémon;
        }

        public async void InsertIntoDB()
        {
            foreach (var pokémon in await GetAllPokémonAsync())
            {
                await _dbContext.AddAsync(pokémon);
            }

            await _dbContext.SaveChangesAsync();
        }

    }
}
