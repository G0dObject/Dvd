using Dvd.Application.Interfaces.BusinessLogic.Base;
using System.Net;

namespace Dvd.Application.Interfaces.BusinessLogic
{
    public interface IAuthorizationRepository : IGenericRepository<Authorization>
    {
        public bool Correct { get; set; }
    }
}
