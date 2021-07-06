using APITest.Domain;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Data
{
    public interface IPokémonRepo
    {
        Task<IRestResponse> GetAllPokémonAsync();
    }
}
