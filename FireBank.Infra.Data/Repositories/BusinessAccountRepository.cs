using FireBank.Domain.Entities;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Infra.Data.Configuration;

namespace FireBank.Infra.Data.Repositories
{
    public class BusinessAccountRepository : BaseRepository<BusinessAccount>, IBusinessAccountRepository
    {
        public BusinessAccountRepository(FireBankContext db) : base(db)
        {

        }
    }
}
