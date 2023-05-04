using Moq;
using unit_tests_web_api.Mocking;

namespace unit_tests_nunit.Mocking;

[TestFixture]
public class VideoServiceTests
{
    private Mock<IFileReader> _fileReader;
    private VideoService _videoService;
    private Mock<IVideoRepository> _repository;

    [SetUp]
    public void SetUp()
    {
        _fileReader = new Mock<IFileReader>();
        _repository = new Mock<IVideoRepository>();
        _videoService = new VideoService(_fileReader.Object, _repository.Object);
    }
    
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
        // var service = new VideoService(new FakeFileReader());
        
        //with moq (together with the setUp)
        _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");
        
        var result = _videoService.ReadVideoTitle();

        Assert.That(result, Does.Contain("error").IgnoreCase);
    }

    [Test]
    public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnAnEmptyString()
    {
        _repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());

        var result = _videoService.GetUnprocessedVideosAsCsv();
        
        Assert.That(result, Is.EqualTo(""));
    }
    
    [Test]
    public void GetUnprocessedVideosAsCsv_AFewUnprocessedVideos_ReturnAStringWithIdOfUnprocessedVideos()
    {
        _repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>
        {
            new Video { Id = 1 },
            new Video { Id = 2 },
            new Video { Id = 3 },
        });

        var result = _videoService.GetUnprocessedVideosAsCsv();
        
        Assert.That(result, Is.EqualTo("1,2,3"));
    }
}