using MediatR;
using Microsoft.Extensions.Configuration;
using RatingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Conference.Application.Queries.GetSuggestions.QueryHandler;

namespace Conference.Application.Queries
{
    public class GetSuggestions
    {
        public class Query : IRequest<List<Model>>
        {
            public string AttendeeEmail { get; set; }
            public int ConferenceId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, List<Model>>
        {
            private readonly RatingDbContext _dbContext;
            public QueryHandler(RatingDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public Task<List<Model>> Handle(Query request, CancellationToken cancellationToken)
            {
                var db = _dbContext.Conferences.Where(x => x.Id != request.ConferenceId);
                var result = db.Select(x => new Model
                {
                    Id = x.Id,
                    ConferenceTypeId = x.ConferenceTypeId,
                    LocationId = x.LocationId,
                    OrganizerEmail = x.OrganizerEmail,
                    CategoryId = x.CategoryId,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Name = x.Name

                })
                    .Take(3)
                    .ToList();
                return Task.FromResult(result);
            }

            public class Model
            {
                public int Id { get; set; }
                public int ConferenceTypeId { get; set; }
                public int LocationId { get; set; }
                public string OrganizerEmail { get; set; }
                public int CategoryId { get; set; }
                public DateTime StartDate { get; set; }
                public DateTime EndDate { get; set; }
                public string Name { get; set; }
            }
        }
    }
}