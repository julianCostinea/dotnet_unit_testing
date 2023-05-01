using unit_tests_web_api.Fundamentals;

namespace unit_tests_nunit;

[TestFixture]
public class ErrorLoggerTests
{
    [Test]
    public void Log_WhenCalled_SetLastErrorProperty()
    {
        var logger = new ErrorLogger();
        
        logger.Log("a");
        
        Assert.That(logger.LastError, Is.EqualTo("a"));
    }
}