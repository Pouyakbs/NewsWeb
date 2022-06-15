using NewsWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWeb.Core.Contracts
{
    public interface IAuthenticationFacade
    {
        IEnumerable<Authentication> GetAuthentications();
        void AddAdmin(Authentication authentication);
    }
}
