using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DataAccessBlazor;
using DataAccessBlazor.Services;
using Microsoft.AspNetCore.Components;

public class OrderService
{
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;

    public OrderService(HttpClient httpClient, NavigationManager navigationManager)
    {
        _httpClient = httpClient;
        _navigationManager = navigationManager;
    }

    public async Task<Order> PostOrder(OrderState orderState)
    {
        var response = await _httpClient.PostAsJsonAsync("api/orders", orderState);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Order>();
        }
        else
        {
            // Manejo de errores
            throw new Exception("Error al crear la orden");
        }
    }
}
