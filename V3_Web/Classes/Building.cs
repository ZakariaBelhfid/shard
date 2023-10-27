using Shard.Shared.Core;

namespace V3_Web.Classes;

public class Building
{
    public string id { get; }
    public string type { get; set; } = "mine";
    public string builderId { get; set; }
    public string system { get; set; }
    public string? planet { get; set; }

    private readonly MapGeneratorOptions _map = new MapGeneratorOptions() { Seed = "test" };

    
    public Building(string builderId, string system, string? planet)
    {
        this.id = GenerateId;
        this.builderId = builderId;
        this.system = system;
        this.planet = planet;
    }

    public Building()
    {
        this.id = GenerateId;
    }
    
    private string GenerateId => Guid.NewGuid().ToString();

    private SystemSpecification GenerateSystem
    {
        get
        {
            var sector = new MapGenerator(_map).Generate().Systems;
            return sector[new Random().Next(0, sector.Count)];
        }
    }

    private PlanetSpecification GeneratePlanet
    {
        get
        {
            var generatedSystem = GenerateSystem;
            return generatedSystem.Planets[new Random().Next(0, generatedSystem.Planets.Count)];
        }
    }
    
}