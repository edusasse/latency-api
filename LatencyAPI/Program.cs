using LatencyAPI.Services;
using LatencyAPI.Services.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILatencyService, LatencyService>();

var app = builder.Build();

app.UseApplicationInsightsRequestTelemetry();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
 //   app.UseSwagger();
  //  app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
