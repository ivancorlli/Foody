namespace Backend.Interface;

public interface IRepository<T> where T : class
{
  public void Create(T Entity);
  public T GetById(Guid Id);
}
