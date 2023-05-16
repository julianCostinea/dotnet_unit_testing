using System.Net;
using Moq;
using Newtonsoft.Json;
using unit_tests_web_api.BookReview;

namespace web_api_integration.tests;

public class BookReviewsControllerTests :IDisposable
{
    private CustomWebApplicationFactory _factory;
    private HttpClient _client;

    public BookReviewsControllerTests()
    {
        _factory = new CustomWebApplicationFactory();
        _client = _factory.CreateClient();
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
    }
    
    [Test]
    public async Task Get_Always_ReturnsAllBooks()
    {
        var mockReviews = new BookReview[]
        {
            new(){ Id = 1, Title="A", Rating = 2 },
            new(){ Id = 2, Title="B", Rating = 3 },
        }.AsQueryable();

        _factory.ReviewRepositoryMock.Setup(r => r.AllReviews).Returns(mockReviews);

        var response = await _client.GetAsync("/BookReviews");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        
        var data = JsonConvert.DeserializeObject<IEnumerable<BookReview>>(await response.Content.ReadAsStringAsync());
        Console.WriteLine("Data:");

        for (var i = 0; i < data.Count(); i++)
        {
            Assert.That(data.ElementAt(i).Title, Is.EqualTo(mockReviews.ElementAt(i).Title));
        }

        Assert.That(data.Count(), Is.EqualTo(2));
        
        _factory.ReviewRepositoryMock.Verify(r => r.AllReviews, Times.Once);
    }
}