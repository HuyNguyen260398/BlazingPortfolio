using Application.Dtos;
using CoreBusiness.Models;

namespace Application.Interfaces;

public interface IUserRepo : IBaseRepo<UserDto>
{
    Task<UserDto> GetUser();
}
