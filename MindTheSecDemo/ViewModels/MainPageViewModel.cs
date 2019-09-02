using System;
using MindTheSecDemo.Models;
using MindTheSecDemo.Services;
using MvvmHelpers;

namespace MindTheSecDemo.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public readonly IPokemonService _pokemonService;

        public ObservableRangeCollection<Pokemon> Pokemons { get; set; }

        public MainPageViewModel()
        {
            _pokemonService = new PokemonService();

            Pokemons = new ObservableRangeCollection<Pokemon>();

            ObterPokemons();
        }

        public async void ObterPokemons()
        {
            var pokemons = await _pokemonService.Todos();
            Pokemons.AddRange(pokemons);
        }
    }
}
