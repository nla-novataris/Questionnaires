using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Users
{
    public class Details
    {
        public class Query : IRequest<UserDto>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, UserDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<UserDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FindAsync(request.Id);

                if (user == null)
                {
                    throw new Exception("Could not find user");
                }

                return _mapper.Map<AppUser, UserDto>(user); ;
            }
        }
    }
}