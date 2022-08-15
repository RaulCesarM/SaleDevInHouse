

using SaleDevInHouse.Data.Contexts;
using SaleDevInHouse.Repository;


var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

builder.Services.AddDbContext<SalesContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();


builder.Services.AddScoped<DeliveryRepository>();
builder.Services.AddScoped<SaleRepository>();
builder.Services.AddScoped<SaleCarRepository>();


var app = builder.Build();
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors(CORS => CORS.AllowAnyHeader()
                         .AllowAnyMethod()
                         .AllowAnyOrigin());
app.MapControllers();
app.Run();
