using RealisticDependencies;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//  Scoped vs Singleton vs Transient
// Scoped: Creates one instance per request (e.g., IDatabase).
// Singleton: Creates one instance for the application's lifetime (e.g., IApplicationLogger).
// Transient: Creates a new instance every time it’s requested.
// For IDatabase, Scoped is ideal because each request gets its own database connection.
builder.Services.AddSingleton<IApplicationLogger, ConsoleLogger>(); // Singleton lifetime
builder.Services.AddSingleton<IAmqpQueue, CloudQueue>(); // Singleton lifetime
builder.Services.AddScoped<IDatabase, Database>(provider =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    var logger = provider.GetRequiredService<IApplicationLogger>();
    return new Database(connectionString, logger);
});
builder.Services.AddScoped<ISendsEmails, Emailer>(provider =>
{
    var logger = provider.GetRequiredService<IApplicationLogger>();
    return new Emailer(logger);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapControllers();
app.Run();


