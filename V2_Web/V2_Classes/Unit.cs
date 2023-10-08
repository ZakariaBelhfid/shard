using Shard.Shared.Core;

namespace V2_Web.V2_Classes
{
    public class Unit
    {
        private string id;
        private string type;
        private string system;
        private string planet;
        private readonly MapGeneratorOptions map = new MapGeneratorOptions() { Seed = "test" };


        public Unit(string id, string type)
        {
            this.id = id;
            this.type = type;
        }


        public string getId() => this.id;
        public string getType() => this.type;

        public void setPlanet(string planet) { this.planet = planet; }
        public void setSystem(string system) { this.system = system; }

        public string getSystem()
        {
            var system = new MapGenerator(map).Generate();
            var systemName = system.Systems.FirstOrDefault(system => system.Name == this.system).Name;
            return this.system = systemName;
        }

        public string getPlanet(string planetName)
        {
            var systems = new MapGenerator(map).Generate();
            var planetNameFounded = "";
            foreach (var system in systems.Systems)
            {
                foreach (var planet in system.Planets)
                {
                    var planetSearchedName = system.Planets.FirstOrDefault(planet => planet.Name == planetName);
                    if (planetSearchedName != null)
                    {
                        planetNameFounded = planet.Name;
                        break;
                    }
                }
            }
            return planetNameFounded;
        }
    }
}
