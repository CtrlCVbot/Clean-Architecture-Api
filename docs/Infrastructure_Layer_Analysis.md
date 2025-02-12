
# Clean Architecture - Infrastructure Layer Analysis

## 프로젝트 개요
`Infrastructure` 레이어는 Clean Architecture에서 **외부 시스템과의 상호작용**을 담당하는 부분으로, 데이터베이스, 인증, 권한 관리, 파일 저장소 등의 기능을 포함합니다.

---

## 폴더 및 주요 구조 분석

### 1. **Infrastructure.csproj**
- `.NET` 프로젝트 파일로, `Infrastructure` 레이어에서 사용되는 패키지 및 프로젝트 참조를 정의.

### 2. **DependencyInjection.cs**
- `Infrastructure` 레이어의 의존성을 `IServiceCollection`을 사용하여 주입하는 구성 파일.
- `Application` 레이어에서 정의한 인터페이스의 구현체를 등록.

### 3. **Authentication (인증 관련)**
- `ClaimsPrincipalExtensions.cs`: `ClaimsPrincipal` 확장을 통해 사용자 정보 접근 기능 추가.
- `PasswordHasher.cs`: `IPasswordHasher` 인터페이스 구현체. 해시 알고리즘을 사용하여 비밀번호 보안 처리.
- `TokenProvider.cs`: `ITokenProvider` 구현체. JWT 토큰 생성 및 검증.
- `UserContext.cs`: `IUserContext` 구현체. 현재 로그인한 사용자의 정보를 제공.

### 4. **Authorization (권한 관리)**
- `HasPermissionAttribute.cs`: 특정 권한을 요구하는 커스텀 `Attribute`.
- `PermissionAuthorizationHandler.cs`: 권한 기반의 `AuthorizationHandler`.
- `PermissionAuthorizationPolicyProvider.cs`: 권한 정책을 관리하는 `IAuthorizationPolicyProvider` 구현체.
- `PermissionProvider.cs`: 시스템에서 사용할 권한 목록을 관리.
- `PermissionRequirement.cs`: 특정 권한을 요구하는 `IAuthorizationRequirement` 구현체.

### 5. **Database (데이터베이스 관련)**
- `ApplicationDbContext.cs`: `IApplicationDbContext` 구현체로, `EF Core`를 기반으로 데이터베이스 접근을 관리.
- `Schemas.cs`: 데이터베이스 테이블 및 스키마 정의.
- `Migrations/`: `EF Core`의 마이그레이션 파일들이 포함됨.
  - `20240811190111_Create_Database.cs`: 초기 데이터베이스 스키마 생성 마이그레이션.
  - `ApplicationDbContextModelSnapshot.cs`: 현재 데이터 모델 스냅샷을 저장.

### 6. **Time (시간 관련)**
- `DateTimeProvider.cs`: 현재 시간을 제공하는 서비스 (`IDateTimeProvider` 구현체).

### 7. **Todos (할 일 관련)**
- `TodoItemConfiguration.cs`: `Entity Framework Core`를 사용한 `Todos` 테이블의 `Fluent API` 설정.

### 8. **Users (사용자 관련)**
- `UserConfiguration.cs`: `Entity Framework Core`를 사용한 `Users` 테이블의 `Fluent API` 설정.

---

## 사용된 프레임워크 및 기술 스택
- **.NET 6/7** (추정) 기반 프로젝트
- **Entity Framework Core**: `ApplicationDbContext`를 통해 데이터베이스 연동.
- **JWT (Json Web Token)**: `TokenProvider`를 통해 인증 및 보안 기능 구현.
- **ASP.NET Core Authorization**: `PermissionAuthorizationHandler` 및 `HasPermissionAttribute`를 통해 권한 관리.
- **Dependency Injection**: `Microsoft.Extensions.DependencyInjection`을 활용하여 의존성 주입.
- **Fluent API**: `EF Core`의 `ModelBuilder`를 사용하여 엔터티 구성.

---

## 프로젝트 구조 분석 결론
- `Infrastructure` 레이어는 **애플리케이션의 외부 의존성을 처리**하는 핵심 역할을 수행.
- `ApplicationDbContext`를 통해 데이터베이스 액세스를 관리하며, `EF Core` 마이그레이션을 활용.
- `Authentication` 및 `Authorization` 모듈을 포함하여 **보안 및 권한 관리** 수행.
- `DependencyInjection.cs`를 통해 **서비스 등록과 관리**가 이루어짐.

이 분석을 바탕으로 `.cursorrules` 파일을 작성할 수 있습니다.
