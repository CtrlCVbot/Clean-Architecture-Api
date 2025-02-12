
# Clean Architecture - Web.Api Layer Analysis

## 프로젝트 개요
`Web.Api` 레이어는 Clean Architecture에서 **애플리케이션의 진입점**을 담당하는 부분으로,  
HTTP 요청을 처리하고 `Application` 레이어와 상호 작용하는 역할을 수행합니다.  
`Minimal API` 방식을 기반으로 `Endpoints` 폴더를 통해 API 엔드포인트를 관리합니다.

---

## 폴더 및 주요 구조 분석

### 1. **Web.Api.csproj**
- `.NET` 프로젝트 파일로, `Web.Api`에서 사용되는 패키지 및 프로젝트 참조를 정의.

### 2. **Program.cs**
- ASP.NET Core 애플리케이션의 진입점.
- `DependencyInjection.cs`를 호출하여 의존성 주입 구성.
- `Minimal API`를 통해 엔드포인트를 등록.

### 3. **DependencyInjection.cs**
- `Application`, `Infrastructure`, `SharedKernel` 등과의 의존성을 등록.

### 4. **Endpoints (API 엔드포인트)**
- `IEndpoint.cs`: 모든 API 엔드포인트에서 공통적으로 구현해야 하는 인터페이스.
- `Tags.cs`: API의 태그를 정의.
- `Todos/`: 할 일(Todo) 관련 API 엔드포인트 모음.
  - `Complete.cs`: 할 일 완료 엔드포인트.
  - `Create.cs`: 할 일 생성 엔드포인트.
  - `Delete.cs`: 할 일 삭제 엔드포인트.
  - `Get.cs`: 모든 할 일 조회 엔드포인트.
  - `GetById.cs`: 특정 할 일 조회 엔드포인트.
- `Users/`: 사용자 관련 API 엔드포인트 모음.
  - `GetById.cs`: 사용자 조회 엔드포인트.
  - `Login.cs`: 사용자 로그인 엔드포인트.
  - `Permissions.cs`: 사용자 권한 조회 엔드포인트.
  - `Register.cs`: 사용자 등록 엔드포인트.

### 5. **Extensions (확장 기능)**
- `ApplicationBuilderExtensions.cs`: `Middleware`, `CORS`, `Swagger` 등의 ASP.NET Core 확장 기능을 등록.

### 6. **설정 파일**
- `appsettings.json`: 애플리케이션의 기본 설정값 포함.
- `appsettings.Development.json`: 개발 환경을 위한 설정 파일.

### 7. **Docker 지원**
- `Dockerfile`: `Docker` 컨테이너를 위한 설정 파일.
- `Dockerfile (.NET 8)`: `.NET 8` 기반 Docker 빌드를 위한 추가 설정.

---

## 사용된 프레임워크 및 기술 스택
- **ASP.NET Core Minimal API**: `Minimal API` 방식을 활용한 경량 API 설계.
- **Dependency Injection**: `Microsoft.Extensions.DependencyInjection`을 사용하여 의존성 관리.
- **JWT 인증 및 보안**: `Authentication`을 통해 사용자 인증 및 권한 부여.
- **Swagger (OpenAPI)**: API 문서를 자동 생성하기 위한 `Swashbuckle.AspNetCore`.
- **CORS 정책 적용**: `ApplicationBuilderExtensions.cs`에서 `CORS` 설정.

---

## 프로젝트 구조 분석 결론
- `Web.Api` 레이어는 **애플리케이션의 진입점** 역할을 수행하며, `Application` 레이어와 상호 작용.
- `Minimal API` 방식을 사용하여 엔드포인트를 구성하고 관리.
- `Endpoints` 폴더를 활용하여 **기능별 API 엔드포인트를 명확하게 분리**.
- `Dependency Injection`을 활용하여 **애플리케이션을 모듈화**하고, 외부 의존성을 명확하게 관리.
- `Dockerfile`을 포함하여 **컨테이너 기반 배포 지원**.

이 분석을 바탕으로 `.cursorrules` 파일을 작성할 수 있습니다.
