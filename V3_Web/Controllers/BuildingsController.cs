using Microsoft.AspNetCore.Mvc;
using V3_Web.Classes;

namespace V3_Web.Controllers;

[ApiController]
[Route("[controller]")]
public class BuildingsController : ControllerBase
{

    [HttpPost("/users/{userId}/Buildings")]
    public Building CreateNewBuilding(string userId, [FromBody] Building building)
    {
        var user = Utilisateur.Instance(userId);
        user.setBuilding(building);
        return user.GetBuilding;
    }
}