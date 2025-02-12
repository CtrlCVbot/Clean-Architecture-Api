//🚀 MigrationExtensions.cs의 주요 역할
//✅ 애플리케이션 실행 시 데이터베이스 마이그레이션 자동 적용
//✅ DI 컨테이너에서 ApplicationDbContext를 가져와 Database.Migrate() 실행
//✅ 초기 배포 시 또는 새로운 마이그레이션 추가 시 데이터베이스를 최신 상태로 유지
//✅ Program.cs에서 app.ApplyMigrations();
//호출만으로 마이그레이션 적용 가능

using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Web.Api.Extensions;

public static class MigrationExtensions
{
    //📌 핵심 역할
    //✅ IApplicationBuilder를 확장하는 확장 메서드(Extension Method) 정의
    //✅ Program.cs에서 app.ApplyMigrations(); 를 호출하면 마이그레이션 자동 적용
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        //📌 핵심 역할
        //✅ DI 컨테이너에서 새로운 스코프(Service Scope) 생성
        //✅ CreateScope()를 사용하여 새로운 IServiceScope 인스턴스를 가져옴
        //✅ 스코프를 사용하면 메모리 관리가 용이해지고, DB 컨텍스트가 올바르게 해제됨
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        //📌 핵심 역할
        //✅ DI 컨테이너에서 ApplicationDbContext 인스턴스를 가져옴
        //✅ GetRequiredService<ApplicationDbContext>() 를 사용하여 필수 종속성 확보
        using ApplicationDbContext dbContext =
            scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        //📌 핵심 역할
        //✅ Database.Migrate()를 호출하여 모든 최신 마이그레이션을 데이터베이스에 적용
        //✅ 마이그레이션이 적용되지 않은 경우, 자동으로 새로운 마이그레이션을 실행하여 DB 스키마를 최신 상태로 유지
        //✅ dotnet ef database update 명령어를 수동으로 실행하지 않아도 됨    
        dbContext.Database.Migrate();
    }
}
