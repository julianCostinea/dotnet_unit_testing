using unit_tests_web_api.Mocking;

namespace unit_tests_nunit.Mocking;

[TestFixture]
public class VideoServiceTests
{
    [Test]
    public void ReadVideoTitle_EmptyFile_ReturnError()
    {
        //dependency with props or params
        // var service = new VideoService();

        // dependency injection with method parameters
        // var result = service.ReadVideoTitle(new FakeFileReader());
        
        // dependency injection with properties
        // service.FileReader = new FakeFileReader();
        
        // dependency injection with constructor
        var service = new VideoService(new FakeFileReader());
        var result = service.ReadVideoTitle();

        Assert.That(result, Does.Contain("error").IgnoreCase);
    }
}