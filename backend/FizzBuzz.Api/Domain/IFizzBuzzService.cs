namespace FizzBuzz.Api.Domain;

public interface IFizzBuzzService
{
    IReadOnlyList<string> Generate(FizzBuzzRequest request);
}
