using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AccountController : BaseApiController
{
  private readonly DataContext _context;
  private readonly ITokenSerivce _tokenSerivce;

  public AccountController(DataContext context, ITokenSerivce tokenSerivce)
  {
    _context = context;
    _tokenSerivce = tokenSerivce;
  }

  [HttpPost("Register")] // POST : https://localhost:5001/api/account/register?username=som&password=pwd
  public async Task<ActionResult<UserDTOs>> Register(RegisterDTOs registerDTOs)
  {

    if (await UserExists(registerDTOs.UserName)) return BadRequest("Username is taken");

    using var hmac = new HMACSHA512();

    var user = new AppUser
    {
      UserName = registerDTOs.UserName.ToLower(),
      PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTOs.Password)),
      PasswordSalt = hmac.Key
    };

    _context.Users.Add(user);
    await _context.SaveChangesAsync();

    return new UserDTOs
    {
      UserName = user.UserName,
      Token = _tokenSerivce.CreateToken(user)
    };

  }

  [HttpPost("Login")]

  public async Task<ActionResult<UserDTOs>> Login(LoginDTOs loginDTOs)
  {
    var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDTOs.UserName);

    if (user == null) return Unauthorized("Invalid username");

    using var hmac = new HMACSHA512(user.PasswordSalt);
    Console.WriteLine(hmac);
    var computedhash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTOs.Password));
    Console.WriteLine(computedhash);

    for (int i = 0; i < computedhash.Length; i++)
    {
      if (computedhash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
    }

    return new UserDTOs
    {
      UserName = user.UserName,
      Token = _tokenSerivce.CreateToken(user)
    };

  }

  private async Task<bool> UserExists(string username)
  {
    return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
  }

}
