using NewsWeb.Core.Entities;
using NewsWeb.Infraustraucture.EF;
using System.Collections.Generic;
using System.Linq;

namespace NewsWeb.Infrustructure.Data
{
    public class AuthenticationRepository
    {
        private readonly MyContext Context;
        public AuthenticationRepository()
        {
            Context = new MyContext();
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
