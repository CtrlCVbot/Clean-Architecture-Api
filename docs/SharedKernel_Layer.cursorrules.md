
# Cursor AI Rules for Clean Architecture - SharedKernel Layer

## 규칙 개요
이 `.cursorrules` 파일은 Clean Architecture의 `SharedKernel` 레이어에서 일관된 코드 스타일과 구조를 유지하기 위해 정의되었습니다.

---

## 1. 프로젝트 구조

### 📁 `src/SharedKernel`
- **`SharedKernel.csproj`**: 프로젝트 구성 파일. 외부 라이브러리 최소화.

### 📁 `Entity`
- `Entity.cs`는 모든 엔터티의 **기본 클래스**가 되어야 한다.
- `Id` 속성을 반드시 포함해야 한다.
- `Domain Events` 리스트를 포함하여 이벤트를 관리해야 한다.

### 📁 `Domain Events`
- `IDomainEvent.cs`는 모든 도메인 이벤트의 기본 인터페이스여야 한다.

### 📁 `Result Pattern`
- `Result<T>`는 `Success`, `Failure` 여부를 포함해야 한다.
- `Error.cs`는 비즈니스 로직에서 사용할 오류를 정의해야 한다.
- `ErrorType.cs`는 오류 유형을 Enum으로 정의해야 한다.

### 📁 `Utility`
- `IDateTimeProvider.cs`는 `DateTime` 관련 기능을 제공해야 한다.
- 구현체는 `Infrastructure` 레이어에서 제공해야 한다.

---

## 2. 코드 스타일 가이드

### ✅ 네이밍 규칙
- **엔터티**: `XXX.cs` (예: `Entity.cs`)
- **도메인 이벤트**: `XXXDomainEvent.cs` (예: `TodoItemCreatedDomainEvent.cs`)
- **결과 패턴 클래스**: `Result<T>`, `Error`, `ErrorType`
- **유틸리티 인터페이스**: `IDateTimeProvider`

### ✅ 클래스 설계 원칙
- 엔터티는 **Setter를 최소화**하고 불변성을 유지해야 함.
- 도메인 이벤트를 활용하여 **비즈니스 로직을 엔터티 내부에서 처리**.
- `Result<T>`를 사용하여 **성공/실패 여부를 명확하게 반환**.

### ✅ 도메인 이벤트 사용 규칙
- `IDomainEvent`를 구현하는 이벤트 클래스를 만들어야 함.
- `Entity` 내부에서 `AddDomainEvent()`를 호출하여 이벤트를 등록해야 함.

---

## 3. 코드 예제

### ✅ 올바른 예제

```csharp
public abstract class Entity
{
    public Guid Id { get; protected set; }
    private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
```

### ❌ 잘못된 예제

```csharp
public class Entity
{
    public Guid Id { get; set; } // Setter가 공개됨 (잘못된 설계)
}
```

---

## 4. 의존성 관리 규칙
- `SharedKernel` 레이어는 **외부 라이브러리에 직접 의존하면 안 됨** (예: `EF Core`, `ASP.NET Core`).
- **데이터베이스 연산이 없어야 함** (순수 C# 코드로만 구성).
- `Result<T>`를 사용하여 명확한 성공/실패 처리를 수행.

---

## 5. 테스트 관련 규칙
- `SharedKernel` 레이어의 테스트는 **공통 유틸리티 및 엔터티 로직 검증**에 집중.
- `Result<T>`와 같은 공통 패턴의 동작을 테스트해야 함.

---

## 6. 추가 규칙 및 Best Practices
- **Setter 최소화**: 엔터티는 반드시 캡슐화되어야 함.
- **도메인 이벤트 활용**: 상태 변경 시 반드시 도메인 이벤트를 발생.
- **Result 패턴 활용**: 모든 결과 반환은 `Result<T>`를 사용할 것.

---

## 7. 결론
이 규칙을 준수함으로써 `SharedKernel` 레이어의 순수성과 유지보수성을 극대화할 수 있습니다.  
모든 PR은 `.cursorrules`에 정의된 원칙을 검토한 후 진행해야 합니다.
