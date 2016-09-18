using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app.Data;
using app.Models;

namespace app.ViewComponents
{
    public class PokemonListViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string type)
        {
            var pokemons = await GetPokemonsAsync(type);
            return View(pokemons);
        }

        private Task<IEnumerable<Pokemon>> GetPokemonsAsync(string type)
        {
            return Task.FromResult(GetPokemons(type));
        }

        private IEnumerable<Pokemon> GetPokemons(string type)
        {
            return PokemonProvider.Instance.GetPokemonsByType(type);
        }
    }
}
