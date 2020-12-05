using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Questionnaires;
using Application.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionnairesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public QuestionnairesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = "RequireAdminOnly")]
        [HttpGet]
        public async Task<ActionResult<List<QuestionnaireDto>>> List()
        {
            return await _mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionnaireDto>> Details(string id)
        {
            return await _mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        [Authorize(Policy = "RequireAdminOnly")]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "RequireAdminOnly")]
        public async Task<ActionResult<Unit>> Edit(string id, Edit.Command command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "RequireAdminOnly")]
        public async Task<ActionResult<Unit>> Delete(string id)
        {
            return await _mediator.Send(new Delete.Command{Id = id});
        }

        [HttpPost("answer")]
        public async Task<ActionResult<Unit>> Answer(Answer.Command command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("answer")]
        public async Task<ActionResult<Unit>> UnAnswer(UnAnswer.Command command)
        {
            return await _mediator.Send(command);
        }
    }
}