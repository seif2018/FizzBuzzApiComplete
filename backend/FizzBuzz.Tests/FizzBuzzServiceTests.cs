using FizzBuzz.Api.Domain;
using Xunit;

namespace FizzBuzz.Tests;

public sealed class FizzBuzzServiceTests
{
    private readonly FizzBuzzService _service = new();

    [Fact]
    public void Generate_ShouldReturnExpectedFizzBuzzSequence()
    {
        var result = _service.Generate(new FizzBuzzRequest(3, 5, 15, "Fizz", "Buzz"));
        Assert.Equal(new[] { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz" }, result);
    }

    [Theory]
    [InlineData(0, 5, 15, "Fizz", "Buzz")]
    [InlineData(3, 0, 15, "Fizz", "Buzz")]
    [InlineData(3, 5, 0, "Fizz", "Buzz")]
    [InlineData(3, 5, 15, "", "Buzz")]
    [InlineData(3, 5, 15, "Fizz", "")]
    public void Generate_ShouldThrowArgumentException_WhenInputIsInvalid(int int1, int int2, int limit, string str1, string str2)
    {
        Assert.Throws<ArgumentException>(() => _service.Generate(new FizzBuzzRequest(int1, int2, limit, str1, str2)));
    }
}
