using Dvd.Application.Interfaces.BusinessLogic.Base;
using System.Net;
using Authorization = Dvd.Domain.Entity.Authorization.Authorization;

namespace Dvd.Application.Interfaces.BusinessLogic
{
    public interface IAuthorizationRepository : IGenericRepository<Authorization>
    {
        public bool Correct { get; set; }
    }
}
