using Shard.Shared.Core;

namespace V3_Web.Classes;

public class UnitLocation
{
    private string system;
    private string? planet;
    private Building building;

    private IReadOnlyDictionary<ResourceKind, int> resources
    {
        get
        {
            IReadOnlyDictionary<ResourceKind, int> listOfResources = new Dictionary<ResourceKind, int>();
            for (var i = 0; i < rand.Next(1, 5); i++)
                listOfResources = new RandomShareComputer(rand).GenerateResources(rand.Next(0, 4));
            return listOfResources;
        }
    }
    private MapGeneratorOptions _map = new MapGeneratorOptions();
    private Random rand = new Random();

    public UnitLocation()
    {
        this.system = GenerateSystem.Name;
        this.planet = GeneratePlanet.Name;
        this.building = new Building();
    }
    
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

    private IReadOnlyDictionary<ResourceKind, int> GenerateResources()
    {
        IReadOnlyDictionary<ResourceKind, int> listOfResources = new Dictionary<ResourceKind, int>();
        for (var i = 0; i < rand.Next(1, 5); i++)
            listOfResources = new RandomShareComputer(rand).GenerateResources(rand.Next(0, 4));
        return listOfResources;
    }

    public string GetSystem => system;
    public string? GetPlanet => planet;
    public IReadOnlyDictionary<ResourceKind, int> GetResources => resources;
    public Building GetBuilding => building;
}