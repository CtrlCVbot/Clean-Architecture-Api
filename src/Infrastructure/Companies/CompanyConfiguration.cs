using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Companies;

namespace Infrastructure.Companies
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            // 테이블 이름을 'CorpInfo'로 설정 (기본 값은 'Companies'이지만 이를 변경)
            builder.ToTable("CorpInfo");
            builder.HasKey(x => x.Idx);
        }
    }
}
