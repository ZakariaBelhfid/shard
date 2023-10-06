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
        private readonly MapGeneratorOptions _map = new MapGeneratorOptions() { Seed = "test"};

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

        }

        /*
        [HttpPut("/users/{userId}/Units/{unitId}")] // Change les infos d'une unité d'un user

        [HttpGet("/users/{userId}/Units/{unitId}/location")] // Retourne + d'infos sur la localisation d'un unité d'un user
        */   
    }

}
