using ContactBook.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite("Data Source=data.db"));

builder.Services.AddCors(o =>
    o.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAll");
app.UseSwagger(); app.UseSwaggerUI();
app.MapGet("/api/customers",                                        // search
    async (string? search, AppDbContext db) =>
        await db.Customers
                .Where(c => search == null ||
                            EF.Functions.Like(c.FirstName, $"%{search}%") ||
                            EF.Functions.Like(c.LastName , $"%{search}%"))
                .Select(c => new { c.Id, c.FirstName, c.LastName })
                .ToListAsync());

app.MapGet("/api/customers/{id:int}",                               // detail
    async (int id, AppDbContext db) =>
        await db.Customers.FindAsync(id) is { } c
            ? Results.Ok(c)
            : Results.NotFound());

app.MapGet("/api/customers/{id:int}/orders",                        // order history
    async (int id, AppDbContext db) =>
        await db.Orders
                .Where(o => o.Id == id)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync());
				
// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();
*/

app.Run();

/*record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}*/
