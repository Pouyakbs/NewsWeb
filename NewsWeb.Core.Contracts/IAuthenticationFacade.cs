using NewsWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWeb.Core.Contracts
{
    public interface IAuthenticationFacade
    {
        IEnumerable<AdminAuthentication> GetAuthentications();
        void AddAdmin(AdminAuthentication authentication);
    }
}
