using System.Net;
using Moq;
using unit_tests_web_api.Mocking;

namespace unit_tests_nunit.Mocking;

[TestFixture]
public class InstallerHelperTests
{
    private Mock<IFileDownloader> _fileDownloader;
    private InstallerHelper _installerHelper;

    [SetUp]
    public void SetUp()
    {
        _fileDownloader = new Mock<IFileDownloader>();
        _installerHelper = new InstallerHelper(_fileDownloader.Object);
    }
    
    [Test]
    public void DownloadInstaller_DownloadFails_ReturnFalse()
    {
        //this Setup works only for the provided arguments to fd.DownloadFile(), so fd.DownloadFile("example.com", null"), wouldnt work
        //as its not what DownloadInstaller real function uses.
        _fileDownloader.Setup(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
            .Throws<WebException>();
        
        var result = _installerHelper.DownloadInstaller("customer", "installer");
        
        Assert.That(result, Is.False);
    }

    [Test]
    public void DownloadInstaller_DownloadCompletes_ReturnTrue()
    {
        var result = _installerHelper.DownloadInstaller("customer", "installer");

        Assert.That(result, Is.True);
    }
}