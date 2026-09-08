using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarcinSCatFact.Model;

namespace MarcinSCatFact.Services
{
    internal interface IApiService
    {
        Task<CatFact> GetCatFactAsync();
    }
}
