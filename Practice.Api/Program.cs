using Dapper;
using Practice.Api.Data;
using Practice.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

DefaultTypeMap.MatchNamesWithUnderscores = true;

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<DapperContext>();

builder.Services.AddScoped<ProductRepository>();

builder.Services.AddScoped<UserRepository>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

app.Run();