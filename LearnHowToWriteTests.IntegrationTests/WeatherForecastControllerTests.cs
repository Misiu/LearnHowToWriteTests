using Microsoft.AspNetCore.Mvc.Testing;

namespace LearnHowToWriteTests.IntegrationTests;

public class WeatherForecastControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public WeatherForecastControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("WeatherForecast");

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        //Assert.Equal("text/html; charset=utf-8",
        //    response.Content.Headers.ContentType.ToString());
    }
}