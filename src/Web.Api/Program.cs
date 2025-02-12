using Serilog;
using System.Reflection;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Web.Api;
using Web.Api.Extensions;

using Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

// Add services to the container.
builder.Services.AddSwaggerGenWithAuth();
builder.Services
    .AddApplication()
    .AddPresentation()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddControllers(); // 컨트롤러 서비스 추가
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwaggerWithUi();
    app.MapOpenApi();
}

// HTTP 요청을 HTTPS로 리디렉션하는 미들웨어를 추가합니다. 이 미들웨어는 보안이 중요한 웹 애플리케이션에서 HTTP 요청을 자동으로 HTTPS로 리디렉션하여 보안을 강화하는 데 사용
app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.UseAuthentication();

app.UseAuthorization();

app.UseRouting(); // 라우팅 미들웨어 추가
app.MapControllers(); // 컨트롤러 엔드포인트 매핑


await app.RunAsync();


