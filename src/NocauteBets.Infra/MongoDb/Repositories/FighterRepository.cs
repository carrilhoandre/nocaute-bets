using NocauteBets.Domain.Models;
using NocauteBets.Infra.MongoDb.Contexts;
using NocauteBets.Infra.MongoDb.Repositories.Interfaces;

namespace NocauteBets.Infra.MongoDb.Repositories
{
    public class FighterRepository : BaseRepository<Fighter>, IFighterRepository
    {
        public FighterRepository(IMongoDbContext context) : base(context, "Fighters")
        {
        }
    }
}
