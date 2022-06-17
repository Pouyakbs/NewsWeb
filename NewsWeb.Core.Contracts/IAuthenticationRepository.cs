using NewsWeb.Core.Entities;
using System.Collections.Generic;

namespace NewsWeb.Core.Contracts
{
    public interface IAuthenticationRepository
    {
        List<AdminAuthentication> GetAuthentications();
        void AddAdmin(AdminAuthentication authentication);
    }
}
