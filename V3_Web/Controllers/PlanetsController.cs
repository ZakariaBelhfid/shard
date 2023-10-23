using Microsoft.AspNetCore.Mvc;
using Shard.Shared.Core;

namespace V3_Web.Controllers;

[ApiController]
[Route("[controller]")]
public class PlanetsController : ControllerBase
{
    private readonly ILogger<PlanetsController> _logger;
    private readonly MapGeneratorOptions _map = new MapGeneratorOptions(){Seed = "test"};


    /*
    public PlanetsController(ILogger<PlanetsController> logger, MapGeneratorOptions map)
    {
        _logger = logger;
        _map = map;
    }*/

    [HttpGet("/Systems")]
    public IEnumerable<SystemSpecification> GetAllSystems()
    {
        var sector = new MapGenerator(_map).Generate();
        return sector.Systems.ToList();
    }

    [HttpGet("/Systems/{systemName}")]
    public SystemSpecification GetSystem(string systemName)
    {
        var sector = new MapGenerator(_map).Generate();
        return sector.Systems.First(system => system.Name == systemName);
    }

    [HttpGet("/Systems/{systemName}/planets")]
    public IEnumerable<PlanetSpecification> GetPlanetsFromSystem(string systemName)
    {
        var sector = new MapGenerator(_map).Generate();
        var systemChoosen = sector.Systems.First(system => system.Name == systemName);

        return systemChoosen.Planets;
    }


    [HttpGet("/Systems/{systemName}/planets/{planetName}")]
    public PlanetSpecification GetPlanetFromSystem(string systemName, string planetName)
    {
        var sector = new MapGenerator(_map).Generate();
        var planetChoosen = sector.Systems.First(system => system.Name == systemName).Planets
            .First(planet => planet.Name == planetName);

        return planetChoosen;
    }
}