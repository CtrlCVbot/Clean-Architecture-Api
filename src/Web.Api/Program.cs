using System.Reflection;
using Application;

using Infrastructure;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;
using Web.Api;
using Web.Api.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGenWithAuth(); // 스웨거 서비스 추가

builder.Services
    .AddApplication()
    .AddPresentation()
    .AddInfrastructure(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers(); // 컨트롤러 서비스 추가
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwaggerWithUi();

    app.ApplyMigrations();
}

app.UseHttpsRedirection();
app.UseRouting(); // 라우팅 미들웨어 추가
app.MapControllers(); // 컨트롤러 엔드포인트 매핑

await app.Run();