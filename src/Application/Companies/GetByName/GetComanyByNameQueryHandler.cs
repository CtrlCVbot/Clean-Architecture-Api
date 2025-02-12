using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Application.Companies.GetByName;
using Application.Users.GetById;
using Domain.Companies;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Companies.GetByName;

internal sealed class GetComanyByNameQueryHandler(IApplicationDbContext context, IUserContext userContext)
    : IQueryHandler<GetComanyByNameQuery, List<CompanyResponse>>
{
    public async Task<Result <List <CompanyResponse> > > Handle(GetComanyByNameQuery query, CancellationToken cancellationToken)
    {
        List<CompanyResponse>? companies = await context.Companies
            .Where(c => c.CorpName.Contains(query.Name))
            .Select(c => new CompanyResponse
            {
                Idx = c.Idx,
                GroupIdx = c.GroupIdx,
                CorpCode = c.CorpCode,
                CorpType = c.CorpType,
                CorpNum = c.CorpNum,
                CorpNameE = c.CorpNameE,
                CorpName = c.CorpName,
                CEO = c.CEO,
                Addr1 = c.Addr1,
                Addr2 = c.Addr2,
                AddrE1 = c  .AddrE1,
                AddrE2 = c  .AddrE2,
                Poix = c.Poix,
                Poiy = c.Poiy,
                PostCode = c.PostCode,
                CntryIdx = c        .CntryIdx,
                CntryCode = c.CntryCode,
                CntryName = c.CntryName,
                CntryNameE = c.CntryNameE,
                CCY = c.CCY,
                BizStatus = c.BizStatus,
                BizType = c.BizType,
                CorpHP = c.CorpHP,
                CorpFAX = c.CorpFAX,
                FoundedTime = c.FoundedTime,
                LicenseFile = c.LicenseFile,
                UseYN = c.UseYN,
                RegUserIdx = c.RegUserIdx,
                RegTime = c.RegTime,
                UpTime = c.UpTime,
                UpUserIdx = c.UpUserIdx

            })
            //.FirstOrDefaultAsync(cancellationToken);
            .ToListAsync(cancellationToken);

        if (companies is null || companies.Count == 0)
        {
            return Result.Failure<List<CompanyResponse>>(CompanyErrors.NotFound(query.Name));
        }

        return companies;
    }
}