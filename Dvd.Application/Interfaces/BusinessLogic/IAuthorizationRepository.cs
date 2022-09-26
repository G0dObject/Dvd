using Dvd.Application.Interfaces.BusinessLogic.Base;
using Dvd.Domain.Entity.Tables;

namespace Dvd.Application.Interfaces.BusinessLogic
{
    public interface IAuthorizationRepository : IGenericRepository<User>
    {
        public Task<Role> GetDefaultRole();
    }
}
