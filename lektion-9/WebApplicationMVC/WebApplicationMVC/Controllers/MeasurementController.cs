using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Services;

namespace WebApplicationMVC.Controllers;

public class MeasurementController : Controller
{
    private readonly MeasurementService _measurementService;
    public MeasurementController(MeasurementService measurementService)
    {
        _measurementService = measurementService;
    }

    public IActionResult Index()
    {
        var measurements = _measurementService.GetMeasurements();
        return View(measurements);
    }
}
