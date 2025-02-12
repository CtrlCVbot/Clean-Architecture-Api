
# Clean Architecture - Domain Layer Analysis

## 프로젝트 개요
`Domain` 레이어는 Clean Architecture에서 **핵심 비즈니스 로직과 엔터티 정의**를 담당하는 부분입니다.  
이 레이어는 **외부 기술 스택에 의존하지 않고** 순수한 C# 코드로만 구성되어야 하며, 애플리케이션의 **비즈니스 규칙과 불변성을 유지**하는 역할을 합니다.

---

## 폴더 및 주요 구조 분석

### 1. **Domain.csproj**
- `.NET` 프로젝트 파일로, `Domain` 레이어에서 사용되는 최소한의 패키지 참조를 정의.

### 2. **Todos (할 일 관련 엔터티 및 이벤트)**
- `Priority.cs`: 할 일(Todo)의 우선순위를 나타내는 열거형(Enum).
- `TodoItem.cs`: 할 일을 나타내는 주요 엔터티.
- `TodoItemCompletedDomainEvent.cs`: 할 일이 완료되었을 때 발생하는 도메인 이벤트.
- `TodoItemCreatedDomainEvent.cs`: 할 일이 생성되었을 때 발생하는 도메인 이벤트.
- `TodoItemDeletedDomainEvent.cs`: 할 일이 삭제되었을 때 발생하는 도메인 이벤트.
- `TodoItemErrors.cs`: 할 일 관련 에러 정의.

### 3. **Users (사용자 관련 엔터티 및 이벤트)**
- `User.cs`: 사용자를 나타내는 주요 엔터티.
- `UserRegisteredDomainEvent.cs`: 사용자가 등록되었을 때 발생하는 도메인 이벤트.
- `UserErrors.cs`: 사용자 관련 에러 정의.

---

## 사용된 패턴 및 개념

### ✅ 엔터티(Entity)
- `TodoItem.cs`와 `User.cs`는 **불변성과 캡슐화**를 유지해야 함.
- 엔터티 내부에서만 상태를 변경할 수 있도록 **Setter를 제한**해야 함.
- `Domain` 레이어에서는 **데이터베이스 연산이 직접 수행되지 않음**.

### ✅ 도메인 이벤트(Domain Events)
- `IDomainEvent` 인터페이스를 구현하는 이벤트 클래스(`TodoItemCompletedDomainEvent` 등).
- 특정 비즈니스 이벤트가 발생하면 `Domain Event`를 활용하여 **이벤트 기반 비즈니스 로직을 처리**.
- `Infrastructure` 레이어에서 이벤트 핸들러를 구현하여 이벤트를 처리.

### ✅ 값 객체(Value Object)
- `Priority.cs`와 같은 값 객체는 **불변성(Immutable)**을 유지해야 함.
- 값 객체는 **Equals() 및 GetHashCode()를 재정의하여 비교 가능**하도록 설계.

### ✅ 비즈니스 규칙 정의
- `TodoItemErrors.cs` 및 `UserErrors.cs`에서 **비즈니스 로직에서 발생할 수 있는 에러를 정의**.
- 엔터티 내부에서 비즈니스 규칙을 검증하고, 예외(Exception) 대신 도메인 이벤트 또는 에러 클래스를 활용.

---

## 사용된 프레임워크 및 기술 스택
- **순수 C# 코드**만 사용 (외부 종속성 최소화).
- **도메인 이벤트 패턴**을 사용하여 비즈니스 로직을 유지.
- **Enum 및 Value Object 패턴**을 활용하여 불변성을 강화.

---

## 프로젝트 구조 분석 결론
- `Domain` 레이어는 **외부 종속성이 없는 순수한 C# 코드**로 작성됨.
- `Entity`, `Value Object`, `Domain Event` 등의 개념을 활용하여 **비즈니스 로직을 철저히 캡슐화**.
- `Infrastructure` 및 `Application` 레이어에서 `Domain` 레이어의 엔터티와 이벤트를 활용하여 기능을 구현.

이 분석을 바탕으로 `.cursorrules` 파일을 작성할 수 있습니다.
