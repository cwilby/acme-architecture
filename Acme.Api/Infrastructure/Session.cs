using Acme.Core.Domain.Identity;
using Acme.Core.Infrastructure;
using Acme.Core.Repository.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acme.Api.Infrastructure
{
    public class Session : ISession
    {
        private readonly IUserRepository _userRepository;

        public Session(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User CurrentUser
        {
            get
            {
                string name = HttpContext.Current.GetOwinContext().Request.User.Identity.Name;
                return _userRepository.FirstOrDefault(u => u.UserName == name);
            }
        }
    }
}