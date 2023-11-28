namespace Backend.Interface;

public interface IRepository<T> where T : class
{
  public void Create(T Entity);
  public T GetById(Guid Id);
  public IEnumerable<T> GetAll();
  public void Save(T Entity);
}
