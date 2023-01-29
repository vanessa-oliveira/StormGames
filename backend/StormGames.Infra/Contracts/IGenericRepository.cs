namespace StormGames.Infra.Contracts;

public interface IGenericRepository<T> where T : class
{
    public Task<T> Insert(T entity);
    public Task<bool> Update(T entity);
    public Task<bool> Delete(T entity);
}