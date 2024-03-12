using Microsoft.EntityFrameworkCore;
// using Tap.Dotnet.Weather.Data;
// using Wavefront.SDK.CSharp.Common;
// using Wavefront.SDK.CSharp.DirectIngestion;

var builder = WebApplication.CreateBuilder(args);

// var serviceBindings = Environment.GetEnvironmentVariable("SERVICE_BINDING_ROOT") ?? String.Empty;

// var weatherDbHost = System.IO.File.ReadAllText(Path.Combine(serviceBindings, "weather-db-class-claim", "host"));
// var weatherDbName = System.IO.File.ReadAllText(Path.Combine(serviceBindings, "weather-db-class-claim", "database"));
// var weatherDbUsername = System.IO.File.ReadAllText(Path.Combine(serviceBindings, "weather-db-class-claim", "username"));
// var weatherDbPassword = System.IO.File.ReadAllText(Path.Combine(serviceBindings, "weather-db-class-claim", "password"));
// var wavefrontUrl = System.IO.File.ReadAllText(Path.Combine(serviceBindings, "wavefront-api-resource-claim", "host"));
// var wavefrontToken = System.IO.File.ReadAllText(Path.Combine(serviceBindings, "wavefront-api-resource-claim", "token"));

// // setup postgres database
// var weatherDbConnectionString = $"Host={weatherDbHost}; Database={weatherDbName}; Username={weatherDbUsername}; Password={weatherDbPassword};";

// builder.Services.AddDbContext<WeatherDb>(options => options.UseNpgsql(weatherDbConnectionString));

// // setup wavefront
// var wfSender = new WavefrontDirectIngestionClient.Builder(wavefrontUrl, wavefrontToken).Build();
// builder.Services.AddSingleton<IWavefrontSender>(wfSender);

// add dapr client
builder.Services.AddDaprClient(builder => builder
    .UseHttpEndpoint("http://localhost:3500")
    .UseGrpcEndpoint("http://localhost:50001"));

builder.Services.AddControllers();

var app = builder.Build();

// using (var scope = app.Services.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<WeatherDb>();
//     //db.Database.EnsureDeleted();
//     db.Database.EnsureCreated();

//     //var dbCreator = (RelationalDatabaseCreator)db.Database.GetService<IDatabaseCreator>();

//     //if (!dbCreator.HasTables())
//     //{
//     //    dbCreator.CreateTables();
//     //}
// }

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
