using Microsoft.Extensions.Configuration;
using NewClimbingApp.ApplicationServices.API.Domain.Components.Models;
using RestSharp;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NewClimbingApp.ApplicationServices.API.Domain.Components;

public class AccuWeather : IAccuWeather
{
    private readonly RestClient restClient;
    private readonly string? apiKey;
    private readonly string? baseUrl;


    public AccuWeather()
    {
        var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();
        apiKey = configuration["apiKey"];
        baseUrl = configuration["baseUrl"];
        this.restClient = new RestClient(baseUrl);
    }

    public async Task<Weather> Check(string city)
    {
        var requestCityId = new RestRequest("locations/v1/cities/search", Method.Get);
        requestCityId.AddParameter("apikey", apiKey);
        requestCityId.AddParameter("q", city);
        var cityId = await restClient.ExecuteAsync(requestCityId);
        var locationKey = JsonConvert.DeserializeObject<List<City>>(cityId.Content);
        var locKey = locationKey[0].LocationKey;

        var request = new RestRequest("forecasts/v1/daily/1day/{locationKey}", Method.Get);
        request.AddUrlSegment("locationKey", locKey);
        request.AddParameter("apikey", this.apiKey);
        request.AddParameter("language", "pl");
        request.AddParameter("metric", true);
        var response = await restClient.ExecuteAsync(request);
        var weather = JsonConvert.DeserializeObject<Weather>(response.Content);
        return weather;
    }
}