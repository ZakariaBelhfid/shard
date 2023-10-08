using Shard.Shared.Core;
using Microsoft.AspNetCore.Mvc;
using V2_Web.V2_Classes;

namespace V2_Web.Controllers
{

    [ApiController]
    [Route("[unitsController]")]
    public class UnitsController : ControllerBase
    {

        private readonly ILogger<UnitsController> _logger;
        private readonly MapGeneratorOptions _map = new MapGeneratorOptions() { Seed = "test" };

        private readonly List<User> listofusers = new List<User>()
        {
            new User("john.doe", "Jonnhy", new DateTime(1992, 14, 1)),
            new User("ali.burton", "Alistair", new DateTime(1995, 7, 25)),
            new User("david.khan", "David", new DateTime(1990, 8, 16))
        };



        public UnitsController(ILogger<UnitsController> logger)
        {
            this._logger = logger;
        }


        [HttpGet("/users/{userId}/Units")] // Retourne toutes les unités d'un user
        public List<Unit> getUnitsFromUser(string userId)
        {
            var user = new User(userId);
            return user.getAllUnits();
        }


        [HttpGet("/users/[userId}/Units/{unitId}")] // Retourne les infos d'une seule unité d'un user
        public Unit getUnitFromUser(string userId, string unitId)
        {
            var user = new User(userId);
            if (user.getId != null)
            {
                var userUnits = getUnitsFromUser(userId);
                foreach (var unit in userUnits)
                {
                    if (unit.getId() == unitId) return unit;
                }
            }
            return null;
        }

        [HttpPut("/users/{userId}/Units/{unitId}")] // Change les infos d'une unité d'un user
        public Unit changeUnitInfoFromUser(string userId, string unitId, string system, string planet)
        {
            Random rand = new Random();
            var user = new User(userId);
            if (user.getId != null)
            {
                var userUnits = getUnitsFromUser(userId);
                foreach (var unit in userUnits)
                {
                    if (unit.getId() == unitId)
                    {
                        unit.setPlanet(planet);
                        unit.setSystem(system);
                        return unit;
                    }
                }
            }
            return null;
        }

        /*
        [HttpGet("/users/{userId}/Units/{unitId}/location")] // Retourne + d'infos sur la localisation d'un unité d'un user
        public Unit currentUnitLoctionFromUser(string userId, string unitId)
        {

        }
        */
    }

}
