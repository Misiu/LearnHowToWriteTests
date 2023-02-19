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

    //if you do a get request to /Test you should get a 200 and Hello World!
    [Fact]
    public async Task Get_ReturnsOk()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/Test");

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("Hello World!", await response.Content.ReadAsStringAsync());
    }

    //if you do a get request to /Test/Homer you should get a 200 and Hello Homer!
    [Theory]
    [InlineData("Homer", "Hello Homer!")]
    [InlineData("Marge", "Hello Marge!")]
    public async Task Get_WithValidName_ReturnsOk(string name, string expected)
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync($"/Test/{name}");

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected, await response.Content.ReadAsStringAsync());
    }

    //if name is not Homer, Marge, Bart, Lisa or Maggie you should get a 400
    [Fact]
    public async Task Get_WithInvalidName_ReturnsBadRequest()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/Test/John");

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Equal("You are not a Simpson!", await response.Content.ReadAsStringAsync());
    }
}