using System;
using System.Collections;
using System.Collections.Generic;

namespace Classes1103.Model;

public interface IDataService<T>
{
    /// <summary>
    /// Returns all <typeparamref name="T"/>
    /// contained within this <see cref="IAsyncDataService{T}"/>.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<T> FindAll();
    /// <summary>
    /// Returns <typeparamref name="T"/> associated with
    /// <paramref name="id"/> or <see langword="null"/>
    /// if it does not exist.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public T? Find(int id);
    /// <summary>
    /// Adds and saves <paramref name="data"/>.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public void Add(T data);
    /// <summary>
    /// Updates <paramref name="data"/> or throws <see cref="InvalidOperationException"/>
    /// if it is not present.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public void Update(T data);
    /// <summary>
    /// Deletes <paramref name="data"/> if it exists.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public void Delete(T data);
}