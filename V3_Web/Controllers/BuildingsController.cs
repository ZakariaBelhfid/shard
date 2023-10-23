using Microsoft.AspNetCore.Mvc;
using V3_Web.Classes;

namespace V3_Web.Controllers;

[ApiController]
[Route("[controller]")]
public class BuildingsController : ControllerBase
{


    [HttpPost("/users/{userId}/Buildings")]
    public void createNewBuilding(string userId)
    {
        var user = Utilisateur.Instance(userId);
        var userUnits = user.GetUnits;
    }
}