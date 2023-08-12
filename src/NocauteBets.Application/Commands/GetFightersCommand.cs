using MediatR;
using NocauteBets.Application.Results;

namespace NocauteBets.Application.Commands
{
    public class GetFightersCommand : IRequest<IEnumerable<FighterResult>>
    {
    }
}
