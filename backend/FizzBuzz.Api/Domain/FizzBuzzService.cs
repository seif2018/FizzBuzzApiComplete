namespace FizzBuzz.Api.Domain;

public sealed class FizzBuzzService : IFizzBuzzService
{
    private const int MaxLimit = 100_000;

    public IReadOnlyList<string> Generate(FizzBuzzRequest request)
    {
        Validate(request);
        var result = new List<string>(request.Limit);

        for (var number = 1; number <= request.Limit; number++)
        {
            var isMultipleOfInt1 = number % request.Int1 == 0;
            var isMultipleOfInt2 = number % request.Int2 == 0;

            result.Add((isMultipleOfInt1, isMultipleOfInt2) switch
            {
                (true, true) => request.Str1 + request.Str2,
                (true, false) => request.Str1,
                (false, true) => request.Str2,
                _ => number.ToString()
            });
        }

        return result;
    }

    private static void Validate(FizzBuzzRequest request)
    {
        if (request.Int1 <= 0) throw new ArgumentException("int1 must be greater than 0.");
        if (request.Int2 <= 0) throw new ArgumentException("int2 must be greater than 0.");
        if (request.Limit <= 0) throw new ArgumentException("limit must be greater than 0.");
        if (request.Limit > MaxLimit) throw new ArgumentException($"limit must be lower than or equal to {MaxLimit}.");
        if (string.IsNullOrWhiteSpace(request.Str1)) throw new ArgumentException("str1 is required.");
        if (string.IsNullOrWhiteSpace(request.Str2)) throw new ArgumentException("str2 is required.");
    }
}
