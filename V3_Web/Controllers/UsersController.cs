using Microsoft.AspNetCore.Mvc;
using V3_Web.Classes;

namespace V3_Web.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }

    [HttpPut("/users/{id}")]
    public Utilisateur CreateNewUser(string id)
    {
        var createUser = Utilisateur.Instance(id);
        return createUser;
    }

    [HttpGet("/users/{id}")]
    public Utilisateur CreatedUser(string id)
    {
        var createdUser = Utilisateur.Instance(id);
        return createdUser;
    }
}