using Shard.Shared.Core;

namespace V3_Web.Classes;

public class Building
{
    private string id;
    private string type = "mine";
    private string builderId;
    private string system;
    private string? planet;

    private readonly MapGeneratorOptions _map = new MapGeneratorOptions() { Seed = "test" };

    public Building()
    {
        this.id = GenerateId;
        this.builderId = GenerateBuilderId;
        this.system = GenerateSystem.Name;
        this.planet = GeneratePlanet.Name;
    }

    private string GenerateId => Guid.NewGuid().ToString();
    private string GenerateBuilderId => Guid.NewGuid().ToString();

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
    public string GetBuilderId => builderId;
    public string GetType => type;
    public string GetSystem => system;
    public string? GetPlanet => planet;
}