﻿using System;
using System.Threading.Tasks;
using MindTheSecDemo.Models;
using MindTheSecDemo.Services;
using MvvmHelpers;
using Prism.Mvvm;
using Prism.Navigation;

namespace MindTheSecDemo.ViewModels
{
    public class PokemonsPageViewModel : BindableBase, INavigatingAware
    {
        public readonly IPokemonService _pokemonService;

        public ObservableRangeCollection<Pokemon> Pokemons { get; set; }

        public PokemonsPageViewModel()
        {
            _pokemonService = new PokemonService();

            Pokemons = new ObservableRangeCollection<Pokemon>();
        }

        public async Task ObterPokemons()
        {
            Pokemons.AddRange(await _pokemonService.Todos());
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
        {
            await ObterPokemons();
        }
    }
}
