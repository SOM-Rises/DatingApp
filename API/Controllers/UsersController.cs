using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
  private readonly DataContext _dataContext;

  public UsersController(DataContext dataContext)
  {
    _dataContext = dataContext;
  }

  [AllowAnonymous]
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
