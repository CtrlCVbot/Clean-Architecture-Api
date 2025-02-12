namespace Application.Companies.GetByName;

public sealed record CompanyResponse
{
    public int Idx { get; set; }
    public int? GroupIdx { get; set; }
    public string? CorpCode { get; set; }
    public int? CorpType { get; set; }
    public string? CorpNum { get; set; }
    public string? CorpNameE { get; set; }
    public string? CorpName { get; set; }
    public string? CEO { get; set; }
    public string? Addr1 { get; set; }
    public string? Addr2 { get; set; }
    public string? AddrE1 { get; set; }
    public string? AddrE2 { get; set; }
    public double? Poix { get; set; }
    public double? Poiy { get; set; }
    public string? PostCode { get; set; }
    public int? CntryIdx { get; set; }
    public string? CntryCode { get; set; }
    public string? CntryName { get; set; }
    public string? CntryNameE { get; set; }
    public string? CCY { get; set; }
    public string? BizStatus { get; set; }
    public string? BizType { get; set; }
    public string? CorpHP { get; set; }
    public string? CorpFAX { get; set; }
    public DateTime? FoundedTime { get; set; }
    public string? LicenseFile { get; set; }
    public int? UseYN { get; set; }
    public int? RegUserIdx { get; set; }
    public DateTime? RegTime { get; set; }
    public DateTime? UpTime { get; set; }
    public int? UpUserIdx { get; set; }
}