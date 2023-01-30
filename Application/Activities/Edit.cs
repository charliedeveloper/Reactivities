using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Activity.Id);

                _mapper.Map(request.Activity, activity);
                // activity.Title = request.Activity.Title ?? activity.Title;
                // activity.Category = request.Activity.Category ?? activity.Category;
                // activity.Description = request.Activity.Description ?? activity.Description;
                // activity.Date = request.Activity.Date;
                // activity.City = request.Activity.Category ?? activity.City;
                // activity.Venue = request.Activity.Venue ?? activity.Venue;

                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}