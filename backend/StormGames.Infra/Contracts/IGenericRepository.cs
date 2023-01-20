namespace StormGames.Infra.Contracts;

public interface IGenericRepository<T> where T : class
{
    public Task<T> Insert(T entity);
    public void Update(T entity);
    public void Delete(T entity);
}