using FireBank.Domain.Entities.Old;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Infra.Data.Configuration;

namespace FireBank.Infra.Data.Repositories
{
    public class GiroAccountRepository : BaseAccountRepository<GiroAccount>, IGiroAccountRepository
    {
        public GiroAccountRepository(FireBankContext db) : base(db)
        {

        }
    }
}
