using APITest.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Services
{
    public interface IPokémonDataManager
    {
        Task<List<Pokémon>> GetAllPokémonAsync();
        Task<Pokémon> GetPokémonByIdAsync(int id);
        Task<IEnumerable<Pokémon>> GetSpecificTypesAsync(string type);
    }
}
