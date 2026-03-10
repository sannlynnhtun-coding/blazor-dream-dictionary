using Microsoft.JSInterop;

namespace BlazorWasm.DreamDictionary.Services;

public class IndexedDbService
{
    private readonly IJSRuntime _jsRuntime;
    private IJSObjectReference? _module;

    public IndexedDbService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    private async ValueTask EnsureModuleLoaded()
    {
        if (_module == null)
        {
            _module = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/db.js");
        }
    }

    public async Task InitializeAsync()
    {
        await EnsureModuleLoaded();
        await _module!.InvokeVoidAsync("initDb");
    }

    public async Task BulkInsertAsync<T>(IEnumerable<T> data)
    {
        await EnsureModuleLoaded();
        await _module!.InvokeVoidAsync("bulkInsert", data);
    }

    public async Task<List<T>> SearchAsync<T>(string query)
    {
        await EnsureModuleLoaded();
        return await _module!.InvokeAsync<List<T>>("searchDreams", query);
    }

    public async Task<List<T>> GetByGroupIdAsync<T>(int groupId)
    {
        await EnsureModuleLoaded();
        return await _module!.InvokeAsync<List<T>>("getDreamsByGroupId", groupId);
    }

    public async Task ClearAsync()
    {
        await EnsureModuleLoaded();
        await _module!.InvokeVoidAsync("clearDb");
    }
}
