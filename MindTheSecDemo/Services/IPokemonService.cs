using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MindTheSecDemo.Models;

namespace MindTheSecDemo.Services
{
    public interface IPokemonService
    {
        Task<IEnumerable<Pokemon>> Todos();
    }
}
