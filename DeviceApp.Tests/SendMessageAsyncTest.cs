using Newtonsoft.Json;
using System;
using Xunit;
using Xunit.Sdk;

namespace DeviceApp.Tests
{
    public class SendMessageAsyncTest
    {
        [Fact]
        public void SendMessageAsync_ShouldConvertToJson()
        {


            TemperatureModel json = new TemperatureModel
            {
                Temperature = 10,
                Humidity = 20


            };

            string expected = "{\"Temperature\":10,\"Humidity\":20}";
            string actual = JsonConvert.SerializeObject(json);


            Assert.Equal(expected, actual);
        }

    public class TemperatureModel
    {
        public int Temperature { get; set; }
        public int Humidity { get; set; }
    }
}
}
