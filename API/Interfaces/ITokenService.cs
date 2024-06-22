using API.Entities;

namespace API.Interfaces
{

  public interface ITokenSerivce
  {
    string CreateToken(AppUser user);
  }
}