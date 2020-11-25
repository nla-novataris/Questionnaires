using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Application.Dtos;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Users
{
    public class Login
    {
        public class Query : IRequest<UserDto>
        {
            public string UserName {get; set;}
            public string Password { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.UserName).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Query, UserDto>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly SignInManager<AppUser> _signInManager;

            public Handler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
            {
                _userManager = userManager;
                _signInManager = signInManager;
            }

            public async Task<UserDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByNameAsync(request.UserName);

                if (user == null)
                {
                    //throw error
                    //hrow new RestException(HttpStatusCode.Unauthorized.ToString());
                    throw new HttpResponseException(HttpStatusCode.Unauthorized);
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

                if (result.Succeeded)
                {
                    //TODO: Generate token
                    return new UserDto()
                    {
                        Id = user.Id, //bør måske fjernes
                        UserName = user.UserName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Added = user.Added,
                        Token = "This will be a token"
                    };
                }
                
                //throw exception
                //throw new RestException(HttpStatusCode.Unauthorized.ToString());
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
        }
    }
}