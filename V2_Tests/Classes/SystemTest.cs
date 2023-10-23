using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2_Tests.Classes
{
    internal class SystemTest
    {
        private string name;
        private List<PlanetTest> planets;

        public SystemTest()
        {
            planets = new List<PlanetTest>();
        }

        public SystemTest(string name)
        {
            this.name = name;
            planets = new List<PlanetTest>();   
        }

        public void AddPlanet(PlanetTest planet) => planets.Add(planet);    
        public void DeletePlanet(PlanetTest planet) => planets.Remove(planet);
        public bool Contains(PlanetTest planet) => planets.Contains(planet);


        public List<PlanetTest> GetPlanets() => planets;
        public string GetName => name;
    }
}
