
# Cursor AI Rules for Clean Architecture - Application Layer

## 규칙 개요
이 `.cursorrules` 파일은 Clean Architecture의 `Application` 레이어에서 일관된 코드 스타일과 구조를 유지하기 위해 정의되었습니다.

---

## 1. 프로젝트 구조

### 📁 `src/Application`
- **`Application.csproj`**: 프로젝트 구성 파일. 불필요한 패키지 추가 금지.
- **`DependencyInjection.cs`**: `IServiceCollection`을 사용하여 서비스 등록.

### 📁 `Abstractions`
- 인터페이스와 공통 기능을 정의.
- 구체적인 구현은 `Infrastructure` 레이어에서 처리.

### 📁 `Todos`
- CQRS 패턴을 따른다.
- 모든 `Command`는 `CommandHandler`와 `Validator`를 포함해야 한다.

---

## 2. 코드 스타일 가이드

### ✅ 네이밍 규칙
- **인터페이스**: `I` 접두어 사용 (예: `IApplicationDbContext`)
- **Command 클래스**: `XXXCommand` (예: `CreateTodoCommand`)
- **Query 클래스**: `XXXQuery` (예: `GetTodoQuery`)
- **핸들러 클래스**: `XXXHandler` (예: `CreateTodoCommandHandler`)
- **유효성 검사 클래스**: `XXXValidator` (예: `CreateTodoCommandValidator`)

### ✅ 클래스 설계 원칙
- 모든 `Command`와 `Query`는 `MediatR`을 사용하여 처리.
- `Abstractions`에 정의된 인터페이스는 구현체가 `Infrastructure`에 존재해야 함.
- `Application` 레이어에서는 데이터베이스 연산이 직접 이루어지면 안됨.

### ✅ MediatR 사용 규칙
- 모든 `Command`와 `Query`는 `IRequest<T>`를 구현해야 함.
- 모든 핸들러는 `IRequestHandler<TRequest, TResponse>`를 구현해야 함.
- `Pipeline Behaviors`를 통한 로깅 및 유효성 검사는 필수.

---

## 3. 코드 예제

### ✅ 올바른 예제

```csharp
public record CreateTodoCommand(string Title) : IRequest<Guid>;

public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateTodoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = new Todo { Title = request.Title };
        _context.Todos.Add(todo);
        await _context.SaveChangesAsync(cancellationToken);
        return todo.Id;
    }
}
```

### ❌ 잘못된 예제

```csharp
public class CreateTodoService
{
    public Guid Create(string title)
    {
        // 직접 DB 연산 수행 (잘못된 설계)
        var todo = new Todo { Title = title };
        _dbContext.Todos.Add(todo);
        _dbContext.SaveChanges();
        return todo.Id;
    }
}
```

---

## 4. 의존성 관리 규칙
- `Application` 레이어는 **외부 프레임워크에 직접 의존하면 안 됨** (예: `EF Core`, `ASP.NET Core`).
- **모든 데이터 액세스는 `IApplicationDbContext`를 통해 수행**해야 함.

---

## 5. 테스트 관련 규칙
- `Application` 레이어의 테스트는 **순수 비즈니스 로직을 검증하는 단위 테스트**에 집중.
- `MediatR` 핸들러는 단위 테스트를 통해 검증.

---

## 6. 추가 규칙 및 Best Practices
- **FluentValidation 적용**: 모든 `Command`는 대응하는 Validator를 가져야 함.
- **CQRS 준수**: Command는 상태 변경을, Query는 데이터를 반환해야 함.
- **의존성 역전 원칙 (DIP) 준수**: 구현체가 아닌 인터페이스에 의존할 것.

---

## 7. 결론
이 규칙을 준수함으로써 `Application` 레이어의 유지보수성과 확장성을 높일 수 있습니다.  
모든 PR은 `.cursorrules`에 정의된 원칙을 검토한 후 진행해야 합니다.
