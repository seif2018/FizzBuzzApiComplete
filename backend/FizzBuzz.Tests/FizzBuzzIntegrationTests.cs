using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace FizzBuzz.Tests;

public sealed class FizzBuzzIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public FizzBuzzIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Get_ShouldReturnOkAndExpectedResult()
    {
        var result = await _client.GetFromJsonAsync<string[]>("/api/fizzbuzz?int1=3&int2=5&limit=15&str1=Fizz&str2=Buzz");
        Assert.NotNull(result);
        Assert.Equal("FizzBuzz", result![14]);
    }

    [Fact]
    public async Task Get_ShouldReturnBadRequest_WhenParametersAreInvalid()
    {
        var response = await _client.GetAsync("/api/fizzbuzz?int1=0&int2=5&limit=15&str1=Fizz&str2=Buzz");
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Health_ShouldReturnOk()
    {
        var response = await _client.GetAsync("/health");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
