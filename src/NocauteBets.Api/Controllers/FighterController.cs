using MediatR;
using Microsoft.AspNetCore.Mvc;
using NocauteBets.Application.Commands;
using NocauteBets.Application.Results;

namespace NocauteBets.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FighterController : ControllerBase
    {
        private readonly ILogger<FighterController> _logger;
        private readonly IMediator _mediator;

        public FighterController(ILogger<FighterController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<FighterResult>> Get()
        {
            return await _mediator.Send(new GetFightersCommand());
        }

        [HttpPatch]
        public async Task<int> Import()
        {
            return await _mediator.Send(new ImportFightersCommand());
        }

    }
}