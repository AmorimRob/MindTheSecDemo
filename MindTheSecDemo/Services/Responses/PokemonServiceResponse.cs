using System;
using MindTheSecDemo.Models;

namespace MindTheSecDemo.Services.Responses
{
    public class PokemonServiceResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public Pokemon[] Results { get; set; }

    }
}
