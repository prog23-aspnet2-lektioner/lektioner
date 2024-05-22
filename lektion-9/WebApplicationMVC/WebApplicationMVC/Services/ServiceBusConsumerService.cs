
using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Services;

public class ServiceBusConsumerService : BackgroundService
{
    private readonly ServiceBusClient _client;
    private readonly ServiceBusProcessor _processor;
    private readonly MeasurementService _measurementService;

    public ServiceBusConsumerService(ServiceBusClient client, MeasurementService measurementService)
    {
        _client = client;
        _processor = _client.CreateProcessor("measurements");
        _measurementService = measurementService;
    }

    private async Task ProcessMessageHandler(ProcessMessageEventArgs args)
    {
        string messageBody = args.Message.Body.ToString();

        var measurement = JsonConvert.DeserializeObject<MeasurementModel>(messageBody);
        _measurementService.AddMeasurement(measurement);

        await args.CompleteMessageAsync(args.Message);
    }

    private Task ProcessErrorHandler(ProcessErrorEventArgs args)
    {
        return Task.CompletedTask;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _processor.ProcessMessageAsync += ProcessMessageHandler;
        _processor.ProcessErrorAsync += ProcessErrorHandler;
        await _processor.StartProcessingAsync(stoppingToken);
    }

}
