using WebApplicationMVC.Models;

namespace WebApplicationMVC.Services;

public class MeasurementService
{
    private readonly List<MeasurementModel> _measurements = [];


    public IEnumerable<MeasurementModel> GetMeasurements()
    {
        return _measurements;
    }

    public void AddMeasurement(MeasurementModel measurement)
    {
        _measurements.Add(measurement);
    }
}
