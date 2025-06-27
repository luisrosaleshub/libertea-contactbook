using ContactBook.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adding configuration for max customers to return
const int DEFAULT_MAX_CUSTOMERS = 100;

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
    async (string? search, int? limit, AppDbContext db) =>
    {
        var maxCustomers = limit ?? DEFAULT_MAX_CUSTOMERS;
        
        if (string.IsNullOrWhiteSpace(search))
            return await db.Customers
                .Select(c => new { 
                    c.Id, 
                    FirstName = c.FirstName == null ? "" : c.FirstName, 
                    LastName = c.LastName == null ? "" : c.LastName 
                })
                .Take(maxCustomers)
                .ToListAsync();

        var terms = search.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var query = db.Customers.AsQueryable();
        
        foreach (var term in terms)
        {
            var searchTerm = term; // Create a closure-safe copy
            query = query.Where(c => 
                EF.Functions.Like((c.FirstName == null ? "" : c.FirstName), "%" + searchTerm + "%") ||
                EF.Functions.Like((c.LastName == null ? "" : c.LastName), "%" + searchTerm + "%"));
        }
        
        return await query
            .Select(c => new { 
                c.Id, 
                FirstName = c.FirstName == null ? "" : c.FirstName, 
                LastName = c.LastName == null ? "" : c.LastName 
            })
            .Take(maxCustomers)
            .ToListAsync();
    });

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
