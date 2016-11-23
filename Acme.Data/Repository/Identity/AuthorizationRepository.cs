using Acme.Core.Domain.Identity;
using Acme.Core.DTO.Customer;
using Acme.Core.DTO.Employee;
using Acme.Data.Context;
using Acme.Data.Infrastructure;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;

namespace Acme.Core.Repository.Identity
{
    public class AuthorizationRepository : IAuthorizationRepository, IDisposable
    {
        private readonly IUserStore<User, int> _userStore;
        private readonly IDatabaseFactory _databaseFactory;
        private readonly UserManager<User, int> _userManager;

        private AcmeDataContext db;
        protected AcmeDataContext Db => db ?? (db = _databaseFactory.GetDataContext());

        public AuthorizationRepository(IDatabaseFactory databaseFactory, IUserStore<User, int> userStore)
        {
            _userStore = userStore;
            _databaseFactory = databaseFactory;
            _userManager = new UserManager<User, int>(userStore);
        }

        public async Task<IdentityResult> RegisterCustomerAsync(CustomerDTO.Registration customer)
        {
            var user = new User
            {
                Customer = new Domain.Customer.Customer
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address1 = customer.Address1,
                    Address2 = customer.Address2,
                    City = customer.City,
                    State = customer.State,
                    Zip = customer.Zip
                },
                UserName = customer.EmailAddress
            };

            user.Customer.Emails.Add(new Domain.Customer.CustomerEmail
            {
                Address = customer.EmailAddress
            });

            if(!string.IsNullOrEmpty(customer.Telephone))
            {
                user.Customer.Phones.Add(new Domain.Customer.CustomerPhone
                {
                    PhoneTypeId = Domain.PhoneTypes.Home,
                    Number = customer.Telephone
                });
            }

            var result = await _userManager.CreateAsync(user, customer.Password);

            var roleResult = await _userManager.AddToRoleAsync(user.Id, "Customer");

            return result;
        }

        public async Task<IdentityResult> RegisterEmployee(EmployeeDTO.Registration employee)
        {
            var user = new User
            {
                Employee = new Domain.Employee.Employee
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Address1 = employee.Address1,
                    Address2 = employee.Address2,
                    City = employee.City,
                    State = employee.State,
                    Zip = employee.Zip
                },
                UserName = employee.EmailAddress
            };

            user.Employee.Emails.Add(new Domain.Employee.EmployeeEmail
            {
                Address = employee.EmailAddress
            });

            if(!string.IsNullOrEmpty(employee.Telephone))
            {
                user.Employee.Phones.Add(new Domain.Employee.EmployeePhone
                {
                    PhoneTypeId = Domain.PhoneTypes.Home,
                    Number = employee.Telephone
                });
            }

            var result = await _userManager.CreateAsync(user, employee.Password);

            var roleResult = await _userManager.AddToRoleAsync(user.Id, "Employee");

            return result;
        }
        public async Task<User> FindUser(string userName, string password)
        {
            return await _userManager.FindAsync(userName, password);
        }

        public void Dispose()
        {
            _userManager.Dispose();
        }
    }
}
