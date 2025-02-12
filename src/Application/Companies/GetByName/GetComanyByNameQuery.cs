using Application.Abstractions.Messaging;

namespace Application.Companies.GetByName;

public sealed record GetComanyByNameQuery(string Name) : IQuery<List<CompanyResponse>>;

