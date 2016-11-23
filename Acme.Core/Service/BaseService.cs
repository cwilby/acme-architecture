using Acme.Core.Domain.Identity;
using Acme.Core.Infrastructure;

namespace Acme.Core.Service
{
    public class BaseService
    {
        protected readonly ISession _session;

        public BaseService(ISession session)
        {
            _session = session;
        }

        protected User CurrentUser
        {
            get
            {
                return _session.CurrentUser;
            }
        }

        protected string UpdateErrorMessage(string entityName)
        {
            return $"There was an error updating {entityName}";
        }
    }
}
