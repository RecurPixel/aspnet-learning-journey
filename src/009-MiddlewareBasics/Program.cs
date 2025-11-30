using MiddlewareBasics.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<InterfaceBasedMiddleware>();

var app = builder.Build();

app.Use(
    async (context, _next) =>
    {
        context.Response.Headers["X-Custom-Header"] = "Custom Header Added";
        await _next(context);
    }
);


app.UserCustomMiddleware();
app.UserCustomInterfaceMiddleware();


app.MapGet("/", () => "Hello Wrold");

app.Run();



// // Notes:
// // If we use convention based middleware
//     - we can use extension method to register it or directly inside program.cs call app.UseMiddleware<Custom>()
//     - as Convention based middleware handles it's own dependency it does not beed to be added into servies DI
// // If we are using IMiddleware based(factory) based middleware it is required to add it to Service container as to handle dependency

// // UseMiddleware When called on any custom middleware it passed context and request delegate to the middleware invoke method