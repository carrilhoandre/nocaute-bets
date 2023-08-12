using NocauteBets.Domain.Models;
using NocauteBets.Infra.SqlServer.Contexts;
using NocauteBets.Infra.SqlServer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NocauteBets.Infra.SqlServer.Repositories
{
    public class FighterRepository : BaseRepository<Fighter>, IFighterRepository
    {
        public FighterRepository(NocauteBetsDbContext context) : base(context) { }
    }
}
