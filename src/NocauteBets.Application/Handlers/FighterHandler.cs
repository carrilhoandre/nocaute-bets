using MediatR;
using Microsoft.EntityFrameworkCore;
using NocauteBets.Application.Commands;
using NocauteBets.Application.Results;
using NocauteBets.Domain.Models;
using NocauteBets.Infra.SqlServer.Repositories.Interfaces;
using NocauteBets.Infra.SqlServer.Uow;
using System.Text;
using System.Text.Json;

namespace NocauteBets.Application.Handlers
{
    public class FighterHandler : IRequestHandler<GetFightersCommand, IEnumerable<FighterResult>>,
                                  IRequestHandler<ImportFightersCommand, int>
    {
        private readonly IFighterRepository _fighterRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FighterHandler(IFighterRepository fighterRepository, IUnitOfWork unitOfWork)
        {
            _fighterRepository = fighterRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<FighterResult>> Handle(GetFightersCommand request, CancellationToken cancellationToken)
        {
            return _fighterRepository.AsQueryable().AsNoTrackingWithIdentityResolution().Select(c => new FighterResult()
            {
                Name = c.Name,
                Cartel = c.Cartel,
                Category = c.Category,
                ImageUrl = c.ImageUrl,
                Nickname = c.Nickname
            }).ToList();
        }

        public async Task<int> Handle(ImportFightersCommand request, CancellationToken cancellationToken)
        {
            var fightersJson = File.ReadAllText(@"C:\Users\Andre\dev\output\fighters.json");
            var fightersToImport = JsonSerializer.Deserialize<IEnumerable<Fighter>>(fightersJson);
            if (fightersToImport != null && fightersToImport.Any())
            {
                int pendingCommits = 0;
                foreach (var fighter in fightersToImport)
                {
                    byte[] bytes = Encoding.Default.GetBytes(fighter.Nickname.Replace("\"", ""));
                    fighter.SetNickname(Encoding.UTF8.GetString(bytes));
                    fighter.SeCartel(fighter.Cartel.Replace(" (V-D-E)", ""));
                    _fighterRepository.AddAsync(fighter);
                    pendingCommits++;
                    if (pendingCommits == 100)
                    {
                        _unitOfWork.Commit();
                        pendingCommits = 0;
                    }
                }
                if (pendingCommits > 0)
                    _unitOfWork.Commit();

                return fightersToImport?.Count() ?? 0;
            }
            else
                return 0;
        }
    }
}
