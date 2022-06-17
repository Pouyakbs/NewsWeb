using NewsWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWeb.Core.Contracts
{
    public interface IUserAuthenticationFacade
    {
        IEnumerable<UserAuthentication> GetAuthentications();
        void AddUser(UserAuthentication userAuthentication);
        void DeleteUser(int id);
        public UserAuthentication UserProfile(int id);
    }
}
