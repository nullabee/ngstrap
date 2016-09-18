using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Data
{
    public class PokemonStats
    {
        public async Task<int> GetPokemonCount()
        {
            return await Task.FromResult(PokemonProvider.Instance.GetAll.Count());
        }

        public async Task<int> GetPokemonCountByType(string type)
        {
            return await Task.FromResult(PokemonProvider.Instance.GetPokemonsByType(type).Count);
        }
    }
}
