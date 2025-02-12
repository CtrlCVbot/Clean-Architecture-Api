
# Clean Architecture - SharedKernel Layer Analysis

## 프로젝트 개요
`SharedKernel` 레이어는 Clean Architecture에서 **공통적으로 사용되는 개념과 유틸리티**를 정의하는 부분입니다.  
이 레이어는 **다른 모든 도메인 및 애플리케이션 레이어에서 공유될 수 있는 요소들**을 포함하며, **비즈니스 독립적인 코드**를 유지합니다.

---

## 폴더 및 주요 구조 분석

### 1. **SharedKernel.csproj**
- `.NET` 프로젝트 파일로, `SharedKernel` 레이어에서 사용되는 패키지를 최소화.

### 2. **Entity (공통 엔터티 기본 클래스)**
- `Entity.cs`: 모든 엔터티에서 공통적으로 사용할 기본 엔터티 클래스.
  - `Id` 속성을 포함하여 엔터티를 식별.
  - `Domain Events` 리스트를 포함하여, 도메인 이벤트 트리거링 가능.

### 3. **Domain Events (도메인 이벤트 인터페이스)**
- `IDomainEvent.cs`: 모든 도메인 이벤트의 기본 인터페이스.

### 4. **Result Pattern (결과 패턴)**
- `Result.cs`: 성공 및 실패를 표현하는 `Result<T>` 패턴을 구현.
  - `Success`, `Failure` 여부를 쉽게 확인할 수 있도록 설계.
- `Error.cs`: 도메인 및 애플리케이션에서 발생할 수 있는 오류를 정의.
- `ErrorType.cs`: 오류 유형을 열거형(Enum)으로 정의.
- `ValidationError.cs`: 유효성 검사 오류를 처리.

### 5. **Utility (유틸리티)**
- `IDateTimeProvider.cs`: 날짜 및 시간을 제공하는 인터페이스.
  - `Infrastructure` 레이어에서 실제 구현체를 제공.

---

## 사용된 패턴 및 개념

### ✅ 엔터티(Entity) 패턴
- `Entity` 클래스는 모든 엔터티의 기본 클래스 역할을 함.
- `ID` 속성을 기본적으로 제공하며, `Domain Events` 리스트를 포함.

### ✅ 도메인 이벤트(Domain Events)
- `IDomainEvent` 인터페이스를 통해 도메인 이벤트를 정의.
- `Entity`에서 `AddDomainEvent()`를 호출하여 이벤트를 발생.

### ✅ Result 패턴
- `Result<T>`를 통해 성공과 실패를 명확하게 구분.
- `Error` 객체를 포함하여 실패 원인을 반환.

### ✅ 유틸리티 제공
- `IDateTimeProvider`를 통해 날짜 및 시간에 대한 의존성을 추상화.

---

## 사용된 프레임워크 및 기술 스택
- **순수 C# 코드**만 사용 (외부 종속성 최소화).
- **Entity Pattern** 및 **Domain Event Pattern** 활용.
- **Result Pattern**을 통한 함수 반환 방식 표준화.

---

## 프로젝트 구조 분석 결론
- `SharedKernel` 레이어는 **공통 개념을 정의**하고 **비즈니스 로직과 분리**됨.
- `Entity`, `Domain Events`, `Result`, `Utility` 등의 개념을 활용하여 **재사용 가능한 코드 작성**.
- `Application`, `Domain`, `Infrastructure`에서 공통적으로 사용할 핵심 요소 제공.

이 분석을 바탕으로 `.cursorrules` 파일을 작성할 수 있습니다.
