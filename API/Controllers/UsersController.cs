using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // /api/users
public class UsersController : ControllerBase
{
  private readonly DataContext _dataContext;

  public UsersController(DataContext dataContext)
  {
    _dataContext = dataContext;
  }

  [HttpGet] //api/users
  public async Task<ActionResult<IEnumerable<AppUser>>> GetUser()
  {
    var users = await _dataContext.Users.ToListAsync();
    return users;
  }

  [HttpGet("{id}")] //api/users/2
  public async Task<ActionResult<AppUser>> GetUser(int id)
  {
    var users = await _dataContext.Users.FindAsync(id);
    return users;
  }
}
