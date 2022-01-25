using Application.Interfaces;
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

    public async Task<User> GetUser()
    {
        return await Task.FromResult(_users.First());
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(User userToUpdate)
    {
        _users[0] = userToUpdate;
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
