using System.Collections;
using System.Collections.Generic;

namespace Classes1103.Model;

public interface IDataService<T>
{
    public IEnumerable<T> FindAll();
    public T? Find(int id);
    public void Add(T data);
    public void Update(T data);
    public void Delete(T data);
}