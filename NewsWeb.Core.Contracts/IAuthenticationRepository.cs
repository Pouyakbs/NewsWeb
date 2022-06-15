using NewsWeb.Core.Entities;
using System.Collections.Generic;

namespace NewsWeb.Core.Contracts
{
    public interface IAuthenticationRepository
    {
        List<Authentication> GetAuthentications();
        void AddAdmin(Authentication authentication);
    }
}
