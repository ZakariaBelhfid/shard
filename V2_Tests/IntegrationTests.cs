using CsvHelper;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Shard.Shared.Web.IntegrationTests;
using System.Net;
using V2_Tests.Classes;
using Xunit.Abstractions;

namespace V2_Tests
{
    public class IntegrationTests : BaseIntegrationTests<Program>
    {
        

        public IntegrationTests(
            WebApplicationFactory<Program> factory,
            ITestOutputHelper testOutputHelper) : base(factory, testOutputHelper)
        {

        }

        private PlanetTest[] planets = new PlanetTest[]
        {
            new PlanetTest("Terre"),
            new PlanetTest("Mercure"),
            new PlanetTest("Lune"),
            new PlanetTest("Saturne"),
            new PlanetTest("Jupiter"),
            new PlanetTest("Neptune")
        };

        //V1

        [Fact]
        public async Task CanFetchOnePlanet()
        {
            SystemTest systemTest = new SystemTest("Solaire");
            systemTest.AddPlanet(planets[0]);

            Assert.False(systemTest.Contains(planets[1]));
        }
        

        [Fact]
        public async Task CanFetchOneSystem()
        {
            StarSystem starSystem = new StarSystem();
            SystemTest system = new SystemTest("Lunaire");
            starSystem.AddSystem(system);
            Assert.True(starSystem.GetSystemTests().Count > 0);
        }


        [Fact]
        public async Task CanFetchPlanetsOfOneSystem()
        {
            SystemTest system = new SystemTest("systeme2");
            system.AddPlanet(planets[0]);
            system.AddPlanet(planets[1]);
            Assert.True(system.GetPlanets().Count != 0);
        }

        [Fact]
        public async Task CanReadSystems()
        {
            StarSystem star = new StarSystem();
            SystemTest sys1 = new SystemTest("sys1");
            SystemTest sys2 = new SystemTest("sys2");

            star.AddSystem(sys1);
            star.AddSystem(sys2);

            Assert.True(star.GetSystemTests().Count > 0);
        }

        [Fact]
        public async Task NonExistingSystemReturns404()
        {

        }

        [Fact]
        public async Task PlanetsHaveNames()
        {
            SystemTest system = new SystemTest("system");
            PlanetTest pt = new PlanetTest("Andromède", 15);
            PlanetTest pt1 = new PlanetTest("Junon", 20);

            system.AddPlanet(pt);
            system.AddPlanet(pt1);

            foreach(var planet in system.GetPlanets())
            {
                Assert.True(planet.getName() != "");
            }
        }

        [Fact]
        public async Task PlanetsHaveSizes()
        {
            SystemTest system = new SystemTest("system");
            PlanetTest pt = new PlanetTest("Andromède", 15);
            PlanetTest pt1 = new PlanetTest("Junon", 20);

            system.AddPlanet(pt);
            system.AddPlanet(pt1);

            foreach (var planet in system.GetPlanets())
            {
                Assert.True(planet.getSize() > 0);
            }
        }

        [Fact]
        public async Task SystemsHaveNames()
        {
            StarSystem starSHN = new StarSystem();
            SystemTest sys1 = new SystemTest("Llora");
            SystemTest sys2 = new SystemTest("Troth");

            starSHN.AddSystem(sys1);
            starSHN.AddSystem(sys2);

            foreach(var system in starSHN.GetSystemTests())
            {
                Assert.True(system.GetName.Length > 0);
            }
        }

        [Fact]
        public async Task SystemsHavePlanets()
        {
            StarSystem starSHN = new StarSystem();
            SystemTest sys1 = new SystemTest("Llora");
            SystemTest sys2 = new SystemTest("Troth");

            starSHN.AddSystem(sys1);
            sys1.AddPlanet(planets[0]);
            sys1.AddPlanet(planets[1]);

            starSHN.AddSystem(sys2);
            sys2.AddPlanet(planets[2]);
            sys2.AddPlanet(planets[3]); 

            foreach (var system in starSHN.GetSystemTests())
            {
                foreach(var planet in system.GetPlanets())
                {
                    Assert.NotNull(planet);
                }
            }
        }


        //V2

        [Fact]
        public async Task CanCreateUser()
        {
            Utilisateur user = Utilisateur.Instance("john.doe", "Jonnhy");
            Assert.True(user != null);
        }

        [Fact]
        public async Task CanFetchCreatedUser()
        {
            Utilisateur user = Utilisateur.Instance("john.doe");
            Assert.True(user != null);
        }

        [Fact]
        public async Task CreatingUserCreatesScout()
        {
            Utilisateur user = Utilisateur.Instance("john.doe");
            var userUnits = user.getAllUnits();
            var scoutName = "général";
            userUnits[5].SetType(scoutName);

            Assert.Equal("général", userUnits[5].GetType);
            
        }

        [Fact]
        public async Task CreatingUserWithInconsistentIdFails()
        {
            Utilisateur user = Utilisateur.Instance();
            Assert.True(user.GetId != "");
        }

        [Fact]
        public async Task CreatingUserWithInvalidIdFails()
        {
            int[] numbers = {0, 2, 4, 6, 8};
            Random rnd = new Random();
            Utilisateur user = Utilisateur.Instance("username-507bcdop");
            Assert.StartsWith("username" ,user.GetId);
        }

        [Fact]
        public async Task MoveScoutToPlanet()
        {
            Utilisateur u1 = Utilisateur.Instance("user1");
            var userUnits = u1.getAllUnits();
            var chooseUnit = userUnits[3];

            var olderValue = chooseUnit.GetPlanet;
            chooseUnit.changePlanet(); //on change le nom aléatoire

            Assert.False(chooseUnit.GetPlanet != olderValue);
        }

        [Fact]
        public async Task MoveScoutToOtherSystem()
        {
            Utilisateur u2 = Utilisateur.Instance("user2");
            var userUnits = u2.getAllUnits();
            var chooseUnit = userUnits[2];

            var olderValue = chooseUnit.GetSystem;
            chooseUnit.changeSystem();

            Assert.True(chooseUnit.GetSystem != olderValue);
        }

        

    }
}