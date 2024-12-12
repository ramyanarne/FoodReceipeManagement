using FoodReceipeManagement.Core;
using FoodReceipeManagement.Core.Contracts;
using FoodReceipeManagement.Core.LoggerService;
using FoodReceipeManagement.Core.Manager;
using FoodReceipeManagement.Core.Repository;
using FoodReceipeManagement.Extensions;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigureCors();
builder.Services.ConfigureSqlServerContext(builder.Configuration);

builder.Services.AddScoped<IReceipeManager, ReceipeManager>();
builder.Services.AddScoped<IReceipeRepository, ReceipeRepository>();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IMeasurementUnitRepository, MeasurementUnitRepository>();
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.MigrateDatabase();

app.Run();