using Acme.Core.Domain.Identity;
using Acme.Core.DTO.Customer;
using Acme.Core.DTO.Employee;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;

namespace Acme.Core.Repository.Identity
{
    public interface IAuthorizationRepository : IDisposable
    {
        Task<IdentityResult> RegisterCustomerAsync(CustomerDTO.Registration customer);
        Task<IdentityResult> RegisterEmployee(EmployeeDTO.Registration customer);
        Task<User> FindUser(string userName, string password);
    }
}
