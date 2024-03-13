﻿using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
// using Tap.Dotnet.Weather.Domain;
// using Wavefront.SDK.CSharp.Common;

namespace WeatherWatch.Data.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavoritesController : ControllerBase
    {
        // private readonly WeatherDb weatherDb;
        // private readonly IWavefrontSender wavefrontSender;
        private readonly DaprClient daprClient;
        // private readonly ILogger<FavoritesController> logger;

        public FavoritesController(DaprClient daprClient)
        {
            this.daprClient = daprClient;
        }

        // [HttpGet]
        // public IEnumerable<Favorite> Get()
        // {
        //     if (this.Request.Headers.ContainsKey("X-TraceId"))
        //     {
        //         var start = DateTimeUtils.UnixTimeMilliseconds(DateTime.UtcNow);
        //         Thread.Sleep(100);
        //         var end = DateTimeUtils.UnixTimeMilliseconds(DateTime.UtcNow);

        //         var traceId = this.Request.Headers["X-TraceId"][0];
        //         var spanId = this.Request.Headers["X-SpanId"][0];

        //         this.wavefrontSender.SendSpan(
        //             "Get", start, end, "WeatherData", new Guid(traceId), Guid.NewGuid(),
        //             ImmutableList.Create(new Guid("82dd7b10-3d65-4a03-9226-24ff106b5041")), null,
        //             ImmutableList.Create(
        //                 new KeyValuePair<string, string>("application", "tap-dotnet-weather-data"),
        //                 new KeyValuePair<string, string>("service", "WeatherData.FavoritesController"),
        //                 new KeyValuePair<string, string>("http.method", "GET")), null);
        //     }

        //     var favorites = this.weatherDb.Favorites;

        //     return favorites;
        // }

        // [HttpGet]
        // [Route("{zipCode}")]
        // public void Save(string zipCode)
        // {
        //     if (this.Request.Headers.ContainsKey("X-TraceId"))
        //     {
        //         var start = DateTimeUtils.UnixTimeMilliseconds(DateTime.UtcNow);
        //         Thread.Sleep(100);
        //         var end = DateTimeUtils.UnixTimeMilliseconds(DateTime.UtcNow);

        //         var traceId = this.Request.Headers["X-TraceId"][0];
        //         var spanId = this.Request.Headers["X-SpanId"][0];

        //         this.wavefrontSender.SendSpan(
        //             "Save", start, end, "WeatherData", new Guid(traceId), Guid.NewGuid(),
        //             ImmutableList.Create(new Guid("82dd7b10-3d65-4a03-9226-24ff106b5041")), null,
        //             ImmutableList.Create(
        //                 new KeyValuePair<string, string>("application", "tap-dotnet-weather-data"),
        //                 new KeyValuePair<string, string>("service", "WeatherData.FavoritesController"),
        //                 new KeyValuePair<string, string>("zipcode", zipCode),
        //                 new KeyValuePair<string, string>("http.method", "POST")), null);
        //     }

        //     var favorite = new Favorite();
        //     favorite.ZipCode = zipCode;

        //     try
        //     {
        //         this.weatherDb.Favorites.Add(favorite);
        //         this.weatherDb.SaveChanges();
        //     }
        //     catch(DbUpdateException ex)
        //     {

        //     }
        // }

        [HttpGet]
        [Route("{zipCode}")]
        public string Get(string zipCode)
        {
            Console.WriteLine(zipCode);
            
            daprClient.SaveStateAsync("weatherwatch-extremetemps", zipCode, zipCode);

            return zipCode;
        }
    }
}
