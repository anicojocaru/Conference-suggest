using Conference.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static Conference.Application.Queries.GetSuggestions.QueryHandler;

namespace RatingSystem.WebApi.Controllers
{
[Route("api/suggestions")]
    [ApiController]
    public class SuggestionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SuggestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("List")]
        public async Task<List<Model>> GetConferences(CancellationToken cancellationToken)
        {
            var query = new GetSuggestions.Query();
            var result = await _mediator.Send(query);
            return result;
        }



    }
}