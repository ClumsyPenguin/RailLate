using System.Text.Json;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace RailLate.Shared;

public static class HttpExtensions
{
    public static async Task<IActionResult> HandleRequestAsync<T>(HttpRequest req, IValidator validation,
        Func<T, Task<IActionResult>> handle, bool authorize = true, bool acceptNull = false)
    {
        if (authorize && !req.IsAuthorized())
        {
            return new UnauthorizedResult();
        }

        var body = await req.GetBodyAsync<T>(validation, acceptNull);
        if (body.IsValid)
        {
            return await handle(body.Value);
        }

        return new BadRequestObjectResult(new { Errors = body.ValidationResults.Select(s => s.ErrorMessage) });
    }

    private static bool IsAuthorized(this HttpRequest req) =>
        req.HttpContext.User.HasClaim(x => x.Type == "ClientId");

    public static string? GetClientId(this HttpRequest req) =>
        req.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "ClientId")?.Value;
    
    public static string ReadBodyAsync(HttpRequest req)
    {
        var bodyStream = new StreamReader(req.Body);
        bodyStream.BaseStream.Seek(0, SeekOrigin.Begin);
        var bodyText = bodyStream.ReadToEnd();
        return bodyText;
        
    }
}

public class HttpResponseBody<T>
{
    public bool IsValid { get; set; }
    public T Value { get; set; }

    public IEnumerable<ValidationFailure> ValidationResults { get; set; }
}

public static class HttpRequestExtensions
{
    public static async Task<HttpResponseBody<T>> GetBodyAsync<T>(this HttpRequest request, IValidator validation,
        bool acceptNull)
    {
        var body = new HttpResponseBody<T>();
        var bodyString = HttpExtensions.ReadBodyAsync(request);
        body.Value = JsonSerializer.Deserialize<T>(bodyString);
        if (!acceptNull && body.Value == null)
        {
            body.IsValid = false;
            body.ValidationResults = new List<ValidationFailure>
                { new ("Request", "Request cannot be null") };
        }
        if(acceptNull)
        {
            body.IsValid = true;
        }
        else
        {
            var context = new ValidationContext<object>(body.Value);
            var validationResult = await validation.ValidateAsync(context);
            body.IsValid = validationResult.IsValid;
            body.ValidationResults = validationResult.Errors;
        }

        return body;
    }
}