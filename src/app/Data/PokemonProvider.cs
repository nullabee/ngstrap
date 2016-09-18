using System.Collections.Generic;
using System.Linq;
using app.Models;

namespace app.Data
{
    public class PokemonProvider
    {
        private static PokemonProvider instance;
        public static PokemonProvider Instance
        {
            get {
                if (instance == null) instance = new PokemonProvider();
                return instance;
            }
        }

        private readonly List<Pokemon> pokemons = new List<Pokemon>() {
            new Pokemon { Id = 1, Name = "Bulbasaur", Type="Grass"},
            new Pokemon { Id = 2, Name = "Ivysaur", Type="Grass"},
            new Pokemon { Id = 3, Name = "Venusaur", Type="Grass"},
            new Pokemon { Id = 4, Name = "Charmander", Type="Fire"},
            new Pokemon { Id = 5, Name = "Charmeleon", Type="Fire"},
            new Pokemon { Id = 6, Name = "Charizard", Type="Fire"},
            new Pokemon { Id = 7, Name = "Squirtle", Type="Water"},
            new Pokemon { Id = 8, Name = "Wartortle", Type="Water"},
            new Pokemon { Id = 9, Name = "Blastoise", Type="Water"},
            new Pokemon { Id = 10, Name = "Caterpie", Type="Bug"}
        };

        public IEnumerable<Pokemon> GetAll {
            get { return pokemons; }
        }

        public List<Pokemon> GetPokemonsByType(string type)
        {
            return pokemons.Where(o => o.Type.ToLower().Equals(type.ToLower())).ToList();
        }
    }
}
