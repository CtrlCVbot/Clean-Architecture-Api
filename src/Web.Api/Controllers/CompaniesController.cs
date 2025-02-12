
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Infrastructure;
using Swashbuckle.AspNetCore.Annotations;
using Web.Api.Extensions;
using Application.Companies.GetByName;
using Domain.Companies;

namespace Web.FM.Api.Controllers
{
    public class CompaniesController : ControllerBase
    {
        private readonly ISender _sander;

        public CompaniesController(ISender sender)
        {
            _sander = sender;
        }

        // GET: /Companies
        [HttpGet("companyName")]
        public async Task<IResult> GetByName(string name, CancellationToken cancellationToken)
        {
            var query = new GetComanyByNameQuery(name);
            Result<List<CompanyResponse>> result = await _sander.Send(query, cancellationToken);

            
            return result.Match(Results.Ok, CustomResults.Problem);
        }
    }
}
