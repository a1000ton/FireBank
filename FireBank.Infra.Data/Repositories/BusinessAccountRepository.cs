using FireBank.Domain.Entities.Old;
using FireBank.Domain.Interfaces.Repository;
using FireBank.Infra.Data.Configuration;

namespace FireBank.Infra.Data.Repositories
{
    public class BusinessAccountRepository : BaseAccountRepository<BusinessAccount>, IBusinessAccountRepository
    {
        public BusinessAccountRepository(FireBankContext db) : base(db)
        {

        }
    }
}
