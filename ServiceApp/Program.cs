using Microsoft.Azure.Devices;
using System;
using System.Threading.Tasks;

namespace ServiceApp
{
    class Program
    {
        private static ServiceClient serviceClient = ServiceClient.CreateFromConnectionString("HostName=EC-iothub.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=wCIx9CZhxPRw9ZAEredokQ7Z5Qm/F4YLWPpn1eWAYMw=");

        static void Main(string[] args)
        {
            Task.Delay(5000).Wait();


            InvokeMethod("DeviceApp", "SetTelemetryInterval", "5").GetAwaiter();
            Console.ReadKey();
        }


        static async Task InvokeMethod(string deviceID, string methodName, string payload)
        {
            var methodInvocation = new CloudToDeviceMethod(methodName) { ResponseTimeout = TimeSpan.FromSeconds(30) };
            methodInvocation.SetPayloadJson(payload);


            var response = await serviceClient.InvokeDeviceMethodAsync(deviceID, methodInvocation);
            Console.WriteLine($"Response Status: {response.Status}");
            Console.WriteLine(response.GetPayloadAsJson());

        }




    }
}
