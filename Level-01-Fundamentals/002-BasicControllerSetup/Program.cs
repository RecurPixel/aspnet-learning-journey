var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();


// app.UseRouting();
// app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "Home Page!");

app.Run();


// Note:
// For routeing to work the controller class must be public o.w. it will not work