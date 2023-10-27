using Microsoft.AspNetCore.Mvc;
using V3_Web.Classes;

namespace V3_Web.Controllers;

[ApiController]
[Route("[controller]")]
public class BuildingsController : ControllerBase
{

    [HttpPost("/users/{userId}/Buildings")]
    public Building createNewBuilding(string userId, string buildingID, string builderID, string system, string planet)
    {
        var user = Utilisateur.Instance(userId);
        var newBuilding = new Building(
            buildingID,
            builderID,
            system,
            planet
            );
        user.setBuilding(newBuilding);
        return newBuilding;
    }
    
    
}