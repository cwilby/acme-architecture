using Microsoft.AspNet.Identity;
using Acme.Core.Domain.Identity;
using Acme.Core.Infrastructure;
using Acme.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using static System.String;
using Acme.Data.Context;

namespace Acme.Data.Identity
{
    public class UserStore : Disposable, IUserPasswordStore<User, int>,
                             IUserSecurityStampStore<User, int>,
                             IUserRoleStore<User, int>
    {

        private readonly IDatabaseFactory _databaseFactory;

        private AcmeDataContext _db;
        protected AcmeDataContext Db => _db ?? (_db = _databaseFactory.GetDataContext());

        public UserStore(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        #region IUserStore
        public virtual async Task CreateAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            await Task.Factory.StartNew(() => {
                Db.Users.Add(user);
                Db.SaveChanges();
            });
        }

        public virtual async Task DeleteAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            await Task.Factory.StartNew(() =>
            {
                Db.Users.Remove(user);
                Db.SaveChanges();
            });
        }

        public virtual async Task<User> FindByIdAsync(int userId)
        {
            return await Task.Factory.StartNew(() => Db.Users.Find(userId));
        }

        public virtual async Task<User> FindByNameAsync(string userName)
        {
            if (IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException(nameof(userName));

            return await Task.Factory.StartNew(() =>
            {
                return Db.Users.FirstOrDefault(u => u.UserName == userName);
            });
        }

        public virtual async Task UpdateAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            await Task.Factory.StartNew(() =>
            {
                Db.Users.Attach(user);
                Db.Entry(user).State = EntityState.Modified;

                Db.SaveChanges();
            });
        }
        #endregion

        #region IUserPasswordStore
        public virtual async Task<string> GetPasswordHashAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return await Task.FromResult(user.PasswordHash);
        }

        public virtual async Task<bool> HasPasswordAsync(User user)
        {
            return await Task.FromResult(!IsNullOrEmpty(user.PasswordHash));
        }

        public virtual async Task SetPasswordHashAsync(User user, string passwordHash)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            user.PasswordHash = passwordHash;

            await Task.FromResult(0);
        }

        #endregion

        #region IUserSecurityStampStore
        public virtual async Task<string> GetSecurityStampAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return await Task.FromResult(user.SecurityStamp);
        }

        public virtual async Task SetSecurityStampAsync(User user, string stamp)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            user.SecurityStamp = stamp;

            await Task.FromResult(0);
        }
        #endregion

        #region IUserRoleStore
        public async Task AddToRoleAsync(User user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (IsNullOrEmpty(roleName))
            {
                throw new ArgumentException("Argument cannot be null or empty: roleName.");
            }

            await Task.Factory.StartNew(() =>
            {
                if (!Db.Roles.Any(r => r.Name == roleName))
                {
                    Db.Roles.Add(new Role
                    {
                        Name = roleName
                    });
                }

                Db.UserRoles.Add(new UserRole
                {
                    Role = Db.Roles.FirstOrDefault(r => r.Name == roleName),
                    User = user
                });

                Db.SaveChanges();
            });
        }

        public async Task RemoveFromRoleAsync(User user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (IsNullOrEmpty(roleName))
            {
                throw new ArgumentException("Argument cannot be null or empty: roleName.");
            }

            await Task.Factory.StartNew(() =>
            {
                var userRole = user.Roles.FirstOrDefault(r => r.Role.Name == roleName);

                if (userRole == null)
                {
                    throw new InvalidOperationException("User does not have that role");
                }

                Db.UserRoles.Remove(userRole);

                Db.SaveChanges();
            });
        }

        public async Task<IList<string>> GetRolesAsync(User user)
        {
            return await Task.Factory.StartNew(() =>
            {
                return (IList<string>)user.Roles.Select(r => r.Role.Name).ToList();
            });
        }

        public async Task<bool> IsInRoleAsync(User user, string roleName)
        {
            return await Task.Factory.StartNew(() =>
            {
                return user.Roles.Any(r => r.Role.Name == roleName);
            });
        }
        #endregion
    }
}
