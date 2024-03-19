using System.Runtime.Intrinsics.Arm;
using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;
using Rede.Social.Server.Repository;

namespace Rede.Social.Server.Infra.Data;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task Add(User obj)
    {
        await _appDbContext.Users.AddAsync(obj);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task Delete(string id)
    {
        var obj = _appDbContext.Users.First(a => a.Id == id);
        if (obj != null)
        {
            obj.Status = false;
            _appDbContext.Update(obj);
            await _appDbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<User>> GetAll(int page, int itemsPerPage)
    {
        int skip = (page - 1) * itemsPerPage;
        return _appDbContext.Users
            .OrderBy(u => u.Id)
            .Skip(skip)
            .Take(itemsPerPage);
    }

    public async Task<User> getByLogin(string login)
    {
        return await _appDbContext.Users.Where(a => a.Email == login).FirstAsync();
    }

    public async Task<User> GetId(string id)
    {
        return await _appDbContext.Users.Where(a => a.Id == id).FirstAsync();
    }

    public async Task Update(User obj)
    {
        _appDbContext.Update(obj);
        await _appDbContext.SaveChangesAsync();
    }
}
