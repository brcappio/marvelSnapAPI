var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
var app = builder.Build();

app.UseCors(builder => builder
    .WithOrigins("http://localhost:4200/")
    .WithMethods("GET")
    .AllowAnyHeader()
);

app.MapGet("/data", () =>
{
    var json = System.IO.File.ReadAllText("data/CardsDatabase.json");
    return json;
}).WithName("GetData");

app.Run();