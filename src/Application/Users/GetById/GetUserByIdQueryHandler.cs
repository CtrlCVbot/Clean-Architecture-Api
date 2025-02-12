using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Users.GetById;

internal sealed class GetUserByIdQueryHandler(IApplicationDbContext context, IUserContext userContext)
    : IQueryHandler<GetUserByIdQuery, UserResponse>
{
    public async Task<Result<UserResponse>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        // 테이블 존재 여부 확인
        //var tableExists = await context.Database.ExecuteSqlRawAsync(
        //"SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'UserInfo'") > 0;
        //if (!tableExists)
        //{
        //    return Result.Failure<UserResponse>(new Error("TableNotFound", "The table 'UserInfo' does not exist.", ErrorType.NotFound));
        //}
        // ✅ SQL 직접 실행 대신 LINQ로 테이블 존재 확인
        bool tableExists = await context.Users.AnyAsync();

        if (!tableExists)
        {
            return Result.Failure<UserResponse>(new Error("TableNotFound", "The table 'UserInfo' does not exist.", ErrorType.NotFound));
        }



        //if (query.Idx != userContext.Idx)
        //{
        //    return Result.Failure<UserResponse>(UserErrors.Unauthorized());
        //}

        UserResponse? user = await context.Users
            .Where(u => u.Idx == query.Idx)
            .Select(u => new UserResponse
            {
                Idx = u.Idx,
                CorpName = u.CorpName,
                UserTeam = u.UserTeam,
                UserName = u.UserName,
                UserHP = u.UserHP
            })
            .SingleOrDefaultAsync(cancellationToken);

        if (user is null)
        {
            return Result.Failure<UserResponse>(PortErrors.NotFound(query.Idx));
        }

        return user;
    }
}
