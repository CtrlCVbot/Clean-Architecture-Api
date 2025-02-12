using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SharedKernel;


//🚀 ValidationError의 역할
//✅ 모든 검증 오류를 하나의 객체(ValidationError)로 통합
//✅ 각 검증 오류(Error[])를 저장하여 API에서 여러 개의 오류를 처리할 수 있도록 함
//✅ 유효성 검사 실패 시 ErrorType.Validation을 사용하여 일반적인 오류와 구별
//
//📌 예를 들어, 사용자 등록 시 여러 개의 입력 값이 잘못되었을 때, 각각의 오류를 하나로 묶어 API 응답으로 반환할 수 있습니다.
public sealed record ValidationError : Error
{
    public ValidationError(Error[] errors)
        : base(
            "Validation.General",
            "One or more validation errors occurred",
            ErrorType.Validation)
    {
        Errors = errors;
    }

    //일반적인 오류(Error)와 구별되며, 검증 실패 시 여러 오류를 묶어서 제공하는 역할을 합니다.
    //✔ 여러 개의 검증 오류(Error)를 포함하는 읽기 전용 배열
    //✔ API 응답에서 개별 오류 메시지를 제공할 때 사용
    public Error[] Errors { get; }

    //FromResults() - 여러 개의 실패한 Result에서 검증 오류 생성
    //✔ IEnumerable<Result> 를 입력으로 받아 실패한 Result만 필터링하여 ValidationError 객체 생성
    //✔ Result 객체 중 IsFailure == true인 것들을 골라서 그 안에 있는 Error를 추출
    //✔ 여러 개의 검증 오류를 하나의 ValidationError 객체로 변환
    public static ValidationError FromResults(IEnumerable<Result> results) =>
        new(results.Where(r => r.IsFailure).Select(r => r.Error).ToArray());
}
