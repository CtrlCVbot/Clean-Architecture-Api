//🚀 ApplicationBuilderExtensions.cs의 주요 역할
//✅ 미들웨어 설정을 확장 메서드(Extension Method)로 분리하여 유지보수성 향상
//✅ Swagger 및 Swagger UI 적용(UseSwaggerWithUi)
//✅ 클린한 Program.cs를 유지하면서 미들웨어를 캡슐화

using Microsoft.Extensions.Options;

namespace Web.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseSwaggerWithUi(this WebApplication app)
    {
        //📌 핵심 역할 
        //✅ Swagger 문서화를 활성화(/ swagger 경로에서 API 문서 제공)
        //✅ Swagger UI 추가하여 브라우저에서 API 테스트 가능(/ swagger / index.html)
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Miles First API V1");
            options.RoutePrefix = string.Empty; // 루트 경로에서 Swagger 사용
            options.OAuthUseBasicAuthenticationWithAccessCodeGrant();
        });

        return app;
    }
}
