//🚀 ServiceCollectionExtensions.cs의 주요 역할
//✅ Swagger 문서화 + JWT 인증 적용
//✅ API 보안 설정 추가 (Bearer Token 방식 적용)
//✅ IServiceCollection을 확장하여 DI 컨테이너에 설정을 추가
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Web.Api.Extensions
{
    //internal static class
    //internal: 현재 어셈블리(Web.Api) 내부에서만 접근 가능
    //static: 정적 클래스이므로 인스턴스를 생성할 필요 없이 메서드를 호출 가능
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddSwaggerGenWithAuth(this IServiceCollection services)
        {
            //📌 Swagger 문서 설정
            //✅ AddSwaggerGen() → Swagger를 활성화
            //✅ CustomSchemaIds(id => id.FullName!.Replace('+', '-'))
            //→ C#의 중첩 클래스(+ 포함)를 Swagger에서 정상적으로 표시할 수 있도록 수정
            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(id => id.FullName!.Replace('+', '-'));
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Web.Api", Version = "v1" });


                //📌 JWT 인증 방식 추가
                //✅ Swagger에서 JWT 인증을 지원하도록 설정
                //✅ 사용자가 Swagger UI에서 "Authorize" 버튼을 눌러 Bearer Token을 입력할 수 있도록 설정
                //✅ In = ParameterLocation.Header
                //→ HTTP 요청의 Authorization 헤더에 JWT 토큰을 포함하도록 설정
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter your JWT token in this field",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    BearerFormat = "JWT"
                };

                options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);

                //📌 API 보안 요구 사항 추가
                //✅ Swagger API의 모든 요청에서 JWT 인증이 필요하도록 설정
                //✅ ReferenceType.SecurityScheme
                //→ 위에서 설정한 JWT 인증 스키마를 사용하도록 지정
                //var securityRequirement = new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = JwtBearerDefaults.AuthenticationScheme
                //            }
                //        },
                //        []
                //    }
                //};

                //options.AddSecurityRequirement(securityRequirement);
            });
            return services;
        }
    }
}
