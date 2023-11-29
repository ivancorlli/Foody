namespace Backend.Interface;

public interface IRepository<T> where T : class
{
  public Task Create(T Entity);
  public ValueTask<T?> GetById(Guid Id);
  public IAsyncEnumerable<T> GetAll();
  public Task SaveAsync();
}
