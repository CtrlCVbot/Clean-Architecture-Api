//Entity Framework Core의 DbContext를 상속하여 애플리케이션의 DB 컨텍스트 역할을 수행합니다.
//DbSet<T>을 통해 Domain Entity 테이블과 매핑됩니다.
//OnModelCreating에서 **기본 스키마(Schemas.Default)**를 지정하고, **엔터티 구성 (Fluent API)**를 적용합니다.
//SaveChangesAsync()를 오버라이드하여 도메인 이벤트 (Domain Events)를 발행하는 기능이 추가되었습니다.

using Application.Abstractions.Data;
using Domain.Users;
using Domain.Companies;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Infrastructure.Database;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPublisher publisher)
    : DbContext(options), IApplicationDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.HasDefaultSchema(Schemas.Default);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {

        int result = await base.SaveChangesAsync(cancellationToken);

        await PublishDomainEventsAsync();

        return result;
    }

    private async Task PublishDomainEventsAsync()
    {
        var domainEvents = ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                List<IDomainEvent> domainEvents = entity.DomainEvents;

                entity.ClearDomainEvents();

                return domainEvents;
            })
            .ToList();

        foreach (IDomainEvent domainEvent in domainEvents)
        {
            await publisher.Publish(domainEvent);
        }
    }
}
