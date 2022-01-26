using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using CoreBusiness.Models;

namespace Infrastructure.InMemDb;

public class UserInMemRepo : IUserRepo
{
    private static List<User> _users = new()
    {
        new User
        {
            FirstName = "Huy",
            LastName = "Nguyen",
            DoB = new DateTime(1998, 03, 26).Date,
            Email = "huynguyen260398@gmail.com",
            Phone = "(+84)903336493",
            Address = "Tran Tan Street, HCM City, Viet Nam",
            Study = "University of Greenwich",
            Degree = "Bachelor of Computer Science",
            Interests = "Building websites"
        }
    };

    private readonly IMapper _mapper;

    public UserInMemRepo(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<UserDto> GetUser()
    {
        return await Task.FromResult(_mapper.Map<UserDto>(_users.First()));
    }

    public Task<IEnumerable<UserDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateAsync(UserDto entity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(UserDto userDtoToUpdate)
    {
        _users[0] = _mapper.Map<User>(userDtoToUpdate);
        return await SaveAsync();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsExistsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveAsync()
    {
        return await Task.FromResult(true);
    }
}
