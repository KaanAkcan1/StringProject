using StringPorject.Models;
using StringPorject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<MainService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();


app.MapPost("/save-string", (string[] request, MainService main) =>
{
    var response = main.SaveString(request);

    return Results.Json(new { Success = response.Success });
})
.WithName("SaveString");


app.MapPost("/save-log", (Log request, MainService main) =>
{
    var response = main.SaveLog(request);

    return Results.Json(new { Success = response.Success});
})
.WithName("SaveLog");


app.MapGet("/show-string", (MainService main) =>
{
    var response = main.ShowString();
    if (!response.Success)
        return Results.BadRequest();
    return Results.Ok(response.Data);
})
.WithName("ShowString");

app.MapGet("/show-logs", async (MainService main) =>
{
    var response = main.ShowLogs();
    if (!response.Success)
        return Results.BadRequest();
    return Results.Ok(response.Data);
})
.WithName("ShowLogs");

app.Run();
