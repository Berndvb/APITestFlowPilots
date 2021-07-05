using APITest.Data;
using APITest.Domain;
using APITest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowPilotsAPITest.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PokémonsController : ControllerBase
    {

        private IPokémonDataManager _dataManager;
        public PokémonsController(IPokémonDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pokémon>>> GetAllPokémon()
        {
            return Ok(await _dataManager.GetAllPokémonAsync());
        }

        [HttpGet("SearchId/{id}")]
        public async Task<ActionResult<Pokémon>> GetPokémonByIdAsync(int id)
        {
            return Ok(await _dataManager.GetPokémonByIdAsync(id));
        }

        [HttpGet("SearchType/{type}")]
        public async Task<ActionResult<Pokémon>> GetSpecificTypes(string type)
        {
            return Ok(await _dataManager.GetSpecificTypesAsync(type));
        }

        [HttpPost]
        public async Task<ActionResult<Pokémon>> CreatePokédex([FromBody] List<Pokémon> pokédex)
        {
            return Ok(await _dataManager.CreatePokédexAsync(pokédex));
        }
    }
}
