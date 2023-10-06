using Microsoft.AspNetCore.Mvc;
using Shard.Shared.Core;


namespace V2_Web.Controllers
{

    [ApiController]
    [Route("[planetsController")]
    public class PlanetsController : ControllerBase
    {

        private readonly ILogger<PlanetsController> _logger;
        private readonly MapGeneratorOptions _map= new MapGeneratorOptions() { Seed = "test"};



        [HttpGet("/Systems")] /*Tous les syst�mes*/
        public IEnumerable<SystemSpecification> GetSystems()
        {
            var sectorSpecification = new MapGenerator(_map).Generate();
            var _sector = sectorSpecification.Systems.ToList();
            return _sector;
        }


        [HttpGet("/Systems/{systemName}")] /*Un seul syst�me et ses requ�tes*/
        public SystemSpecification GetSystemAndPlanets(string systemName)
        {
            var systemSpecification = new MapGenerator(_map).Generate();
            var systemAndPlanets = systemSpecification.Systems.FirstOrDefault(system => system.Name == systemName);

            return systemAndPlanets;

        }


        [HttpGet("/Systems/{systemName}/planets")] /*Les plan�tes d'un syst�me*/
        public IEnumerable<PlanetSpecification> GetPlanetsOfSystem(string systemName)
        {
            var systemSpecification = new MapGenerator(_map).Generate();
            var PlanetsOfSystem = systemSpecification.Systems.ToList().FirstOrDefault(system => system.Name == systemName);

            return PlanetsOfSystem.Planets;
        }



        [HttpGet("/Systems/{systemName}/planets/{planetName}")] /*Une seule plan�te*/
        public PlanetSpecification GetPlanet(string systemName, string planetName)
        {
            var systemSpecification = new MapGenerator(_map).Generate();
            PlanetSpecification planet = systemSpecification.Systems
                .Where(system => system.Name == systemName)
                .SelectMany(system => system.Planets)
                .FirstOrDefault(planet => planet.Name.Equals(planetName));

            return planet;
        }


        //Déjà réussit dans la V1 - déposée par FERROL Nelgie et BELHFID Zakaria
    }
}
