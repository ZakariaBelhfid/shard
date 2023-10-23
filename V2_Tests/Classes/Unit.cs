using Shard.Shared.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2_Tests.Classes
{
    internal class Unit
    {
        private string id;
        private string type;
        private string system;
        private string? planet;
        private readonly MapGeneratorOptions map = new MapGeneratorOptions() { Seed = "test" };
        private readonly Random rnd = new Random();


        public Unit(string id, string type = "scout")
        {
            this.id = id;
            this.type = type;

            // Générez la carte et choisissez un système au hasard
            var generatedMap = new MapGenerator(map).Generate();
            var generatedSystems = generatedMap.Systems;
            int randomSystemIndex = rnd.Next(0, generatedSystems.Count);
            var randomSystem = generatedSystems[randomSystemIndex];
            this.system = randomSystem.Name;
            // Choisissez une planète au hasard dans le système sélectionné
            var planetsInSystem = randomSystem.Planets;
            if (planetsInSystem.Count > 0)
            {
                int randomPlanetIndex = rnd.Next(0, planetsInSystem.Count);
                this.planet = planetsInSystem[randomPlanetIndex].Name;
            }
            else
            {
                this.planet = null; // Aucune planète disponible dans ce système
            }
        }

        public void SetId(string id) => this.id = id;
        public void SetType(string type) => this.type = type;

        public string GetId => this.id;
        public new string GetType => this.type;
        public string GetSystem => this.system;

        public string? GetPlanet => planet;

        public void changePlanet() => this.planet = Guid.NewGuid().ToString();

        public void changeSystem() => this.system = Guid.NewGuid().ToString();
    }
}
