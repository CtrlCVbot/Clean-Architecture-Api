using SharedKernel;

namespace Domain.Users;

public sealed class User : Entity
{    
    public int? Idx { get; set; }
    public int? CorpIdx { get; set; }
    public string? CorpName { get; set; }
    public int? CorpType { get; set; }
    public int? UserType { get; set; }
    public string? UserTeam { get; set; }
    public string? UserRank { get; set; }
    public string? UserName { get; set; }
    public string? UserHP { get; set; }
    public string? UserFAX { get; set; }
    public string? UserMail { get; set; }
    public string? UserID { get; set; }
    public string? UserPW { get; set; }
    public string? Note { get; set; }
    public int? Menu_Main { get; set; }
    public int? Menu_OrderList { get; set; }
    public int? Menu_Acct { get; set; }
    public int? Menu_OrderReg { get; set; }
    public int? Menu_CorpInfoClt { get; set; }
    public int? Menu_Statistics { get; set; }
    public int? Menu_Notice { get; set; }
    public int? Menu_Bidding { get; set; }
    public int? RemarkYN { get; set; }
    public int? Remark2YN { get; set; }
    public char? LanguagePack { get; set; }
    public int? EditYN { get; set; }
    public DateTime? RegTime { get; set; }
    public DateTime? UpTime { get; set; }
    public int? RegUserIdx { get; set; }
    public int? UpUserIdx { get; set; }
    public int? UseYN { get; set; }
    public int? User_GroupIdx { get; set; }
    public string? User_GroupName { get; set; }
    public string? UserNameE { get; set; }
    
}
