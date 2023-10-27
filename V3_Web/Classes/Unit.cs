using Shard.Shared.Core;

namespace V3_Web.Classes;

public class Unit
{
    private string id;
    private string type = "scout";
    private string system;
    private string? planet;
    private string destinationSystem, destinationPlanet;
    private string estimatedTimeOfArrival;
    private UnitLocation location;

    private MapGeneratorOptions _map = new MapGeneratorOptions() { Seed = "test" };

    public Unit()
    {
        this.id = GenerateId;
        this.system = GenerateSystem.Name;
        this.planet = GeneratePlanet.Name;
        this.location = new UnitLocation();
    }

    private static string GenerateId => Guid.NewGuid().ToString();
    
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


    public string GetId => id;
    public string GetType => type;
    public string GetPlanet => planet;
    public string GetSystem => system;
    public UnitLocation GetLocation => location;
}