using unit_tests_web_api;

namespace unit_tests_nunit;

[TestFixture]
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_0CelsiusForecast_Returns32F()
    {
        var weatherForecast = new WeatherForecast();
        
        weatherForecast.TemperatureC = 0;
        
        Assert.That(weatherForecast.TemperatureF, Is.EqualTo(32));
    }
}