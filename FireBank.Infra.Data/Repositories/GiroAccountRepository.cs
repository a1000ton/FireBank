using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Infra.Data.Configuration;

namespace FireBank.Infra.Data.Repositories
{
    public class GiroAccountRepository : BaseRepository<GiroAccount>, IGiroAccountRepository
    {
        public GiroAccountRepository(FireBankContext db) : base(db)
        {

        }
    }
}
