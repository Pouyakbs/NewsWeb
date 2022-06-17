using NewsWeb.Core.Contracts;
using NewsWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWeb.Core.ApplicationService
{
    public class UserAuthenticationFacade : IUserAuthenticationFacade
    {
        IUserAuthenticationRepository userAuthenticationRepository;
        public UserAuthenticationFacade(IUserAuthenticationRepository userAuthentication)
        {
            userAuthenticationRepository = userAuthentication;
        }
        public IEnumerable<UserAuthentication> GetAuthentications()
        {
            return userAuthenticationRepository.GetAuthentications();
        }
        public void AddUser(UserAuthentication userAuthentication)
        {
            userAuthenticationRepository.AddUser(userAuthentication);
        }
        public void DeleteUser(int id)
        {
            userAuthenticationRepository.DeleteUser(id);
        }
        public UserAuthentication UserProfile(int id)
        {
            return userAuthenticationRepository.UserProfile(id);
        }
    }
}
