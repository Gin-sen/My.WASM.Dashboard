using Microsoft.Extensions.Configuration;
using My.WASM.Dashboard.Contracts.WeatherForecast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace My.WASM.Dashboard.Infrastructure.HttpClients
{
  public class WeatherForecastHttpClient
  {
    private readonly HttpClient http;
    private readonly string? baseUrl;

    public WeatherForecastHttpClient(HttpClient http, IConfiguration configuration)
    {
      this.http = http;
      this.baseUrl = configuration["SelfUrl"];
    }

    public async Task<WeatherForecast[]?> GetForecastAsync()
    {
      var requestMessage = new HttpRequestMessage()
      {
        Method = new HttpMethod("GET"),
        RequestUri = new Uri($"{baseUrl}sample-data/weather.json"),
        Headers =
        {
          { "Accept-Encoding", "gzip, deflate, br" },
          { "Accept", "application/json" }
        }
      };
      Console.WriteLine(baseUrl);
      try
      {
        //var tokenResult = await TokenProvider.RequestAccessToken();

        //if (tokenResult.TryGetToken(out var token))
        //{
        //  requestMessage.Headers.Authorization =
        //      new AuthenticationHeaderValue("Bearer", token.Value);

        //  requestMessage.Content.Headers.TryAddWithoutValidation(
        //      "x-custom-header", "value");

        var response = await http.SendAsync(requestMessage);
        var responseStatusCode = response.StatusCode;

        var responseBody = await response.Content.ReadAsStringAsync();
        WeatherForecast[]? weatherResult =
                JsonSerializer.Deserialize<WeatherForecast[]>(responseBody);
        //}
        return weatherResult;
      }
      catch
      {
        throw;
      }
    }
  }
}
