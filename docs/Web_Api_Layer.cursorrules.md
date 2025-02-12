
# Cursor AI Rules for Clean Architecture - Web.Api Layer

## 규칙 개요
이 `.cursorrules` 파일은 Clean Architecture의 `Web.Api` 레이어에서 일관된 코드 스타일과 구조를 유지하기 위해 정의되었습니다.

---

## 1. 프로젝트 구조

### 📁 `src/Web.Api`
- **`Web.Api.csproj`**: 프로젝트 구성 파일. 불필요한 패키지 추가 금지.

### 📁 `Endpoints`
- 모든 엔드포인트 클래스는 `IEndpoint` 인터페이스를 구현해야 한다.
- `Todos/` 및 `Users/` 폴더를 활용하여 엔드포인트를 모듈화.
- 엔드포인트 클래스명은 `HTTP 동작`에 맞춰야 한다 (예: `Get.cs`, `Create.cs`).

### 📁 `Extensions`
- `ApplicationBuilderExtensions.cs`는 `Swagger`, `CORS`, `Middleware` 설정을 관리.

### 📁 `설정 파일`
- `appsettings.json` 및 `appsettings.Development.json`을 통해 환경별 설정을 분리.
- **민감한 정보(API 키, 비밀번호 등)는 설정 파일에 직접 포함하면 안 됨**.

### 📁 `Docker`
- `Dockerfile`을 포함하여 컨테이너 배포를 지원.

---

## 2. 코드 스타일 가이드

### ✅ 네이밍 규칙
- **엔드포인트 인터페이스**: `IEndpoint.cs` (모든 엔드포인트에 공통 적용).
- **엔드포인트 파일명**: HTTP 동작을 반영해야 함 (예: `Create.cs`, `Get.cs`).
- **확장 메서드**: `XXXExtensions.cs` (예: `ApplicationBuilderExtensions.cs`).

### ✅ 클래스 설계 원칙
- `Web.Api` 레이어에서는 **비즈니스 로직을 직접 포함하지 않아야 함**.
- `Application` 레이어의 서비스 및 핸들러를 호출하여 비즈니스 로직을 처리.
- `DependencyInjection`을 통해 필요한 서비스 및 컨텍스트를 주입.

### ✅ Minimal API 사용 규칙
- `Endpoints` 폴더 내에서 `Minimal API` 방식으로 엔드포인트를 정의.
- `MapXXX` 확장 메서드를 사용하여 엔드포인트를 `Program.cs`에서 등록.
- `Swagger` 문서화를 위해 `Summary` 및 `Description`을 추가.

---

## 3. 코드 예제

### ✅ 올바른 예제

```csharp
public class Create : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/todos", async (CreateTodoCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Errors);
        })
        .WithTags("Todos")
        .WithSummary("Create a new todo item")
        .WithDescription("Creates a new todo item with the given details.");
    }
}
```

### ❌ 잘못된 예제

```csharp
public class TodoEndpoints
{
    public static void ConfigureEndpoints(WebApplication app)
    {
        app.MapPost("/todos", async (CreateTodoCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Errors);
        });
    }
}
```

- **잘못된 이유**: `IEndpoint` 인터페이스를 구현하지 않음.

---

## 4. 의존성 관리 규칙
- `Web.Api` 레이어는 **`Application` 및 `Infrastructure` 레이어에만 의존**해야 함.
- **비즈니스 로직을 직접 구현하면 안 됨** (`Application` 서비스 호출 필수).
- `DependencyInjection.cs`를 통해 모든 의존성을 `IServiceCollection`에 등록해야 함.

---

## 5. 테스트 관련 규칙
- `Web.Api` 레이어의 테스트는 **엔드포인트 응답 검증**에 집중.
- `Integration Test`를 활용하여 API 동작을 검증해야 함.
- `Minimal API` 엔드포인트의 요청/응답을 `TestServer`를 활용하여 테스트.

---

## 6. 추가 규칙 및 Best Practices
- **Swagger 적용**: 모든 엔드포인트에 `Summary` 및 `Description`을 추가.
- **환경별 설정 관리**: `appsettings.json`을 통해 환경별 설정을 분리.
- **CORS 설정 적용**: `ApplicationBuilderExtensions.cs`에서 CORS 정책을 관리.
- **Docker 지원**: `Dockerfile`을 활용하여 컨테이너 배포 가능하도록 유지.

---

## 7. 결론
이 규칙을 준수함으로써 `Web.Api` 레이어의 유지보수성과 확장성을 극대화할 수 있습니다.  
모든 PR은 `.cursorrules`에 정의된 원칙을 검토한 후 진행해야 합니다.
