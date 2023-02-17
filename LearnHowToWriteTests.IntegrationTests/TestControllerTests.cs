using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;

namespace LearnHowToWriteTests.IntegrationTests;

public class TestControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public TestControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("Test");

        // Assert
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType1()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("Test/John");

        // Assert
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType2()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("Test/Sam");
        response.EnsureSuccessStatusCode();

        //assert that response is "Hello Sam!"
        var responseString = await response.Content.ReadAsStringAsync();
        Assert.Equal("Hello Sam!", responseString);


    }

    public async Task Get_EndpointsReturnSuccessAndCorrectContentType3()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("Test/Joe");

        //assert that response is bad request
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

    }
}