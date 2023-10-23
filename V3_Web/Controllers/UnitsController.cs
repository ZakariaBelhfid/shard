using Microsoft.AspNetCore.Mvc;
using V3_Web.Classes;

namespace V3_Web.Controllers;

[ApiController]
[Route("[controller]")]
public class UnitsController : ControllerBase
{
    private readonly ILogger<UnitsController> _logger;

    public UnitsController(ILogger<UnitsController> logger)
    {
        _logger = logger;
    }
    

    [HttpGet("/users/{userId}/Units")]
    public List<Unit> GetAllUnitsFromUser(string userId)
    {
        var user = Utilisateur.Instance(userId);
        return user.GetUnits;
    }

    [HttpGet("/users/{userId}/Units/{unitId}")]
    public Unit GetSingleUnitFromUser(string userId, string unitId)
    {
        var user = Utilisateur.Instance(userId);
        return user.GetUnits.First(unit => unit.GetId == unitId);
    }

    [HttpGet("/users/{userId}/Units/{unitId}/location")]
    public UnitLocation GetLocationFromSingleUnitOfAUser(string userId, string unitId)
    {
        var user = Utilisateur.Instance(userId);
        return user.GetUnits.First(unit => unit.GetId == unitId).GetLocation;
    }
}