namespace Rede.Social.Server.Repository;

public interface IUserRepository :IReposistoryBase<User>
{
    Task<User> getByLogin(string login);
}
