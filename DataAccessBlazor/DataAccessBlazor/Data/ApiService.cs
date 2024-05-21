using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<MenuItem>> GetMenuItemsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<MenuItem>>("");//menu?category=Pizza
    }

    public async Task<T> GetAsync<T>(string url)
    {
        return await _httpClient.GetFromJsonAsync<T>(url);
    }

    public async Task<HttpResponseMessage> PostAsync<T>(string url, T data)
    {
        return await _httpClient.PostAsJsonAsync(url, data);
    }

    public async Task<HttpResponseMessage> PutAsync<T>(string url, T data)
    {
        return await _httpClient.PutAsJsonAsync(url, data);
    }

    public async Task<HttpResponseMessage> DeleteAsync(string url)
    {
        return await _httpClient.DeleteAsync(url);
    }

}