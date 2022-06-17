using NewsWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWeb.Core.Contracts
{
    public interface IUserAuthenticationRepository
    {
        List<UserAuthentication> GetAuthentications();
        void AddUser(UserAuthentication authentication);
        void DeleteUser(int id);
        public UserAuthentication UserProfile(int id);
    }
}
