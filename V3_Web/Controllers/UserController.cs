using Microsoft.AspNetCore.Mvc;
using V3_Web.Classes;

namespace V3_Web.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpPut("/Users/{id}")]
    public Utilisateur CreateNewUser(string id)
    {
        var createUser = Utilisateur.Instance(id);
        return createUser;
    }

    [HttpGet("/Users/{id}")]
    public Utilisateur CreatedUser(string id)
    {
        var createdUser = Utilisateur.Instance(id);
        return createdUser;
    }
}