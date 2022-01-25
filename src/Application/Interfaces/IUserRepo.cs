using CoreBusiness.Models;

namespace Application.Interfaces;

public interface IUserRepo : IBaseRepo<User>
{
    Task<User> GetUser();
}
