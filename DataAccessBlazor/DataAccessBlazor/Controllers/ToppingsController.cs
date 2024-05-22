using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessBlazor.Data;

namespace DataAccessBlazor.Controllers;

[Route("toppings")]
[ApiController]
public class ToppingsController : Controller
{
    private readonly PizzaStoreContext _db;

    public ToppingsController(PizzaStoreContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Topping>>> GetSpecials()
    {
        return (await _db.Toppings.ToListAsync()).ToList();
    }
}