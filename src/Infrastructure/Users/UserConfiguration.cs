using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Users;

namespace Infrastructure.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // 테이블 이름을 'UserInfo'로 설정 (기본 값은 'Users'이지만 이를 변경)
            builder.ToTable("UserInfo");
            builder.HasKey(x => x.Idx);

            /*builder.ToTable("users", Schemas.Default);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(x => x.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(x => x.Password)
                .HasColumnName("password")
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired();
            builder.HasIndex(x => x.Email)
                .IsUnique();*/
        }
    }
}
