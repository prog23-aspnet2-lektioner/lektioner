using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;

var rnd = new  Random();
var value = rnd.NextDouble();

var serviceBusClient = new ServiceBusClient("Endpoint=sb://sb-prog23.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=P98FPeNGrC29C4g3631nfxSnxgBiCITMl+ASbOJjbyA=");
var sender = serviceBusClient.CreateSender("measurements");

while(true)
{
    await Task.Delay(10000);
    value = rnd.NextDouble();
    
    var message = new ServiceBusMessage(JsonConvert.SerializeObject(new { Measurement = value, Created = DateTime.Now }));
    await sender.SendMessageAsync(message);   
}