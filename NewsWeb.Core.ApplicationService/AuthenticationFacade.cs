using NewsWeb.Core.Contracts;
using NewsWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWeb.Core.ApplicationService
{
    public class AuthenticationFacade : IAuthenticationFacade
    {
        IAuthenticationRepository authenticationRepository;
        public AuthenticationFacade(IAuthenticationRepository authenticationRepository)
        {
            this.authenticationRepository = authenticationRepository;
        }
        public IEnumerable<AdminAuthentication> GetAuthentications()
        {
            return authenticationRepository.GetAuthentications();
        }
        public void AddAdmin(AdminAuthentication authentication)
        {
            authenticationRepository.AddAdmin(authentication);
        }
    }
}
