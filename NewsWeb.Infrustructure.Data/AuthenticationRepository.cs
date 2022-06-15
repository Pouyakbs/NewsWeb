using NewsWeb.Core.Contracts;
using NewsWeb.Core.Entities;
using NewsWeb.Infraustraucture.EF;
using System.Collections.Generic;
using System.Linq;

namespace NewsWeb.Infrustructure.Data
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly MyContext Context;
        public AuthenticationRepository(MyContext Context)
        {
            this.Context = Context;
        }
        public List<Authentication> GetAuthentications()
        {
            return Context.Authentications.ToList();
        }
        public void AddAdmin(Authentication authentication)
        {
            Context.Authentications.Add(authentication);
            Context.SaveChanges();
        }
    }
}
