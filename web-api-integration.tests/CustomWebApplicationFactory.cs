using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using unit_tests_web_api.BookReview;

namespace web_api_integration.tests;

public class CustomWebApplicationFactory: WebApplicationFactory<Program>
{
    public Mock<IReviewRepository> ReviewRepositoryMock { get; }

    public CustomWebApplicationFactory()
    {
        ReviewRepositoryMock = new Mock<IReviewRepository>();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);

        builder.ConfigureTestServices(services =>
        {
            services.AddSingleton(ReviewRepositoryMock.Object);
        });
    }
}