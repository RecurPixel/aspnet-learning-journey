using DependencyInjectionBasics.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IGreetingService, GreetingService>();

builder.Services.AddControllers();
var app = builder.Build();

app.MapGet(
    "/",
    (IGreetingService greet1, IGreetingService greet2) =>
    {
        var g1 = greet1.GetGreeting("Jhon");
        var g2 = greet2.GetGreeting("Jane");

        return new string[] { g1, g2 };
    }
);

app.MapControllers();

app.Run();
