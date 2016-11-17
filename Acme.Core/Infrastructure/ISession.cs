using Acme.Core.Domain.Identity;

namespace Acme.Core.Infrastructure
{
    public interface ISession
    {
        User CurrentUser { get; }
    }
}
