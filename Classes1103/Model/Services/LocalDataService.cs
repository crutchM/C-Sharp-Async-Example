using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes1103.Model.Data;

namespace Classes1103.Model.Services;

public class LocalDataService : 
    IAsyncDataService<SampleInfo>,
    IDataService<SampleInfo>
{
    private readonly Dictionary<int, SampleInfo> _cache = new()
    {
        { 0, new SampleInfo(0, "Иван") }
    };
    private readonly TimeSpan _delay = TimeSpan.FromSeconds(3);
    private Task EmulateDelay() => Task.Delay(_delay);

    #region Async
    
    public async Task<IEnumerable<SampleInfo>> FindAllAsync()
    {
        await EmulateDelay();
        if (Random.Shared.Next(3) % 2 == 0)
            throw new InvalidOperationException("Suck my ass");
        return _cache.Values.AsEnumerable();
    }

    public async Task<SampleInfo?> FindAsync(int id)
    {
        await EmulateDelay();
        return _cache.GetValueOrDefault(id);
    }

    public async Task AddAsync(SampleInfo data)
    {
        await EmulateDelay();
        _cache.Add(data.Id, data);
    }

    public async Task UpdateAsync(SampleInfo data)
    {
        await EmulateDelay();
        if (_cache.TryGetValue(data.Id, out _))
            throw new InvalidOperationException("Соси");
        _cache[data.Id] = data;
    }

    public async Task DeleteAsync(SampleInfo data)
    {
        await EmulateDelay();
        _cache.Remove(data.Id);
    }
    
    #endregion

    #region Sync

    public IEnumerable<SampleInfo> FindAll()
        => _cache.Values;

    public SampleInfo? Find(int id)
        => _cache.GetValueOrDefault(id);

    public void Add(SampleInfo data)
        => _cache.Add(data.Id, data);

    public void Update(SampleInfo data)
    { 
        if (_cache.TryGetValue(data.Id, out _))
            throw new InvalidOperationException("Соси");
        _cache[data.Id] = data;
    }

    public void Delete(SampleInfo data)
        => _cache.Remove(data.Id);
    
    #endregion
}