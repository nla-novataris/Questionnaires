using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistence;

namespace Application.Users
{
    public class Create
    {
        public class Command : IRequest
        {
            public string Id { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public bool? IsAdmin { get; set; }
            public DateTime Added { get; set; }
            
            public string Email { get; set; }
            
            public string Password { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly UserManager<User> _userManager;
            public Handler(DataContext context, UserManager<User> userManager)
            {
                this._context = context;
                this._userManager = userManager;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {

                var user = new User
                {
                    Id = request.Id,
                    UserName = request.UserName,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    IsAdmin = request.IsAdmin,
                    Added = request.Added,
                    Email = request.Email,
                    NormalizedEmail = request.Email.ToUpper(),
                    NormalizedUserName = request.UserName.ToUpper()
                };
                
                await _userManager.CreateAsync(user, request.Password);
                //_context.Users.Add(user);

                /*
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;
                */
                return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}