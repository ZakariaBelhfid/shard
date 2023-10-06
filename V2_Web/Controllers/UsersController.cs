using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shard.Shared.Core;
using System.Text.Json.Nodes;
using V2_Web.V2_Classes;

namespace V2_Web.Controllers
{

    [ApiController]
    [Route("[usersController]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> logger;
        private readonly MapGeneratorOptions map = new MapGeneratorOptions() { Seed = "test"};

        public UsersController(ILogger<UsersController> logger)
        {
            this.logger = logger; 
        }


        [HttpPut("/Users/{id}")] //Créer un nouveau user
        public IActionResult createNewUser(string id, string pseudo, DateTime dateOfCreation)
        {
            User user = new User(id, pseudo, dateOfCreation);
            return Ok("User created succesfully");
        }

        [HttpGet("/Users/{id}")] //Retourne les infos d'un user existant
        public string GetUserDetails(string id)
        {
            var user = new User(id);
            return user != null ? user.ToJson() : "";
        }

        
    }
}
