namespace Rede.Social.Server.Repository;

public interface IReposistoryBase<T> where T : class
{
    Task<T> GetId(string id);
    Task Add(T obj);
    Task Delete(string id);
    Task Update(T obj);
    Task<IEnumerable<User>> GetAll(int pagae, int itemsPerPage);
}
