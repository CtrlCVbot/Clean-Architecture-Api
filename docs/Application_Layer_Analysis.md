
# Clean Architecture - Application Layer Analysis

## 프로젝트 개요
`Application` 레이어는 Clean Architecture의 핵심 부분으로, 비즈니스 로직을 포함하며 도메인과 상호 작용하는 서비스 및 유즈케이스를 담당합니다.

## 폴더 및 주요 구조 분석

### 1. **Application.csproj**
- `.NET` 프로젝트 파일로, `Application` 레이어에서 사용되는 패키지 및 프로젝트 참조를 정의함.

### 2. **DependencyInjection.cs**
- `Application` 레이어의 의존성을 주입하는 구성 파일.
- `IServiceCollection`을 사용하여 서비스들을 등록함.

### 3. **Abstractions 패키지**
- `Application` 레이어에서 추상화된 인터페이스 및 공통 기능을 제공.

#### Authentication
- `IPasswordHasher.cs`: 비밀번호 해싱 인터페이스
- `ITokenProvider.cs`: JWT 또는 기타 토큰 관련 인터페이스
- `IUserContext.cs`: 현재 로그인한 사용자 정보를 제공하는 인터페이스

#### Behaviors
- `RequestLoggingPipelineBehavior.cs`: 요청 로깅을 담당하는 MediatR 파이프라인 동작 정의
- `ValidationPipelineBehavior.cs`: 요청 유효성 검사를 수행하는 MediatR 파이프라인 동작

#### Data
- `IApplicationDbContext.cs`: 애플리케이션에서 사용할 데이터베이스 컨텍스트 인터페이스

#### Messaging
- `ICommand.cs`: CQRS 패턴에서 Command를 표현하는 인터페이스
- `ICommandHandler.cs`: Command를 처리하는 핸들러 인터페이스
- `IQuery.cs`: CQRS 패턴에서 Query를 표현하는 인터페이스
- `IQueryHandler.cs`: Query를 처리하는 핸들러 인터페이스

### 4. **Todos 패키지**
- `Todos` 관련 유즈케이스를 포함하는 폴더로, CQRS 패턴을 기반으로 구성됨.

#### Complete
- `CompleteTodoCommand.cs`: 특정 할 일을 완료하는 Command 클래스
- `CompleteTodoCommandHandler.cs`: 해당 Command를 처리하는 핸들러
- `CompleteTodoCommandValidator.cs`: Command의 유효성 검사

#### Create
- `CreateTodoCommand.cs`: 새로운 할 일을 생성하는 Command
- `CreateTodoCommandHandler.cs`: 생성 Command를 처리하는 핸들러
- `CreateTodoCommandValidator.cs`: 유효성 검사 수행

#### Delete
- `DeleteTodoCommand.cs`: 특정 할 일을 삭제하는 Command
- `DeleteTodoCommandHandler.cs`: 삭제 Command를 처리하는 핸들러

## 사용된 프레임워크 및 기술 스택
- **.NET 6/7** (추정) 기반 프로젝트
- **MediatR**: CQRS 패턴을 적용하기 위한 메시징 라이브러리
- **FluentValidation**: 요청 데이터의 유효성 검사를 담당
- **Dependency Injection**: `Microsoft.Extensions.DependencyInjection`을 활용한 의존성 주입
- **JWT 기반 인증 시스템** (`ITokenProvider`)

## 프로젝트 구조 분석 결론
- `Application` 레이어는 **CQRS 패턴**을 기반으로 설계되었으며, MediatR을 활용하여 명령(Command)과 조회(Query)를 분리.
- `Abstractions` 폴더를 활용하여 **인터페이스 기반 개발**을 철저하게 수행.
- `DependencyInjection.cs`를 통해 **서비스 등록과 관리**가 이루어짐.
- `FluentValidation`을 활용한 **입력 유효성 검사** 적용.
- `IPasswordHasher`, `ITokenProvider` 등을 통해 **보안 및 인증 처리** 포함.

이 분석을 바탕으로 규칙 파일을 작성할 수 있습니다.
