using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BasicAspireStarter.Web.Pages;

public class IndexModel(IHttpClientFactory httpClientFactory) : PageModel
{
    public List<WeatherForecast> Forecasts { get; private set; } = [];

    public string? ErrorMessage { get; private set; }

    public async Task OnGetAsync()
    {
        try
        {
            var httpClient = httpClientFactory.CreateClient("Api");
            Forecasts = await httpClient.GetFromJsonAsync<List<WeatherForecast>>("weatherforecast") ?? [];
        }
        catch (HttpRequestException)
        {
            ErrorMessage = "The API is not available. Start BasicAspireStarter.Api and refresh this page.";
        }
    }
}

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}