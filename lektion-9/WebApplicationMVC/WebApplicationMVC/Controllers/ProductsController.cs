using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers;

public class ProductsController : Controller
{
    public async Task<IActionResult> Index()
    {
        using var http = new HttpClient();
        var items = await http.GetFromJsonAsync<IEnumerable<ProductModel>>("http://localhost:7180/api/GetAll");

        return View(items);
    }







    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(ProductFormModel model)
    {
        if (ModelState.IsValid)
        {
            using var http = new HttpClient();
            var response = await http.PostAsJsonAsync("http://localhost:7180/api/Create", model);

            if (response.IsSuccessStatusCode)
            {
                return LocalRedirect("/");
            }
        }

        return View(model);
    }
}
