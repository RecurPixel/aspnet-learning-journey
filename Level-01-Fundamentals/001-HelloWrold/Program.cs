// Create a builder instance
var builder = WebApplication.CreateBuilder(args);

// build app
var app = builder.Build();

// Map route
app.MapGet(
    "/",
    () =>
    {
        return "Hello, ASP.NET Core!";
    }
);

// Run app/terminal middleware
app.Run();
