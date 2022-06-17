using NewsWeb.Core.Contracts;
using NewsWeb.Core.Entities;
using NewsWeb.Infraustraucture.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsWeb.Infrustructure.Data
{
    public class UserAuthenticationRepository : IUserAuthenticationRepository
    {
        private readonly MyContext Context;
        public UserAuthenticationRepository(MyContext Context)
        {
            this.Context = Context;
        }
        public List<UserAuthentication> GetAuthentications()
        {
            return Context.UserAuthentications.ToList();
        }
        public void AddUser(UserAuthentication userAuthentication)
        {
            Context.UserAuthentications.Add(userAuthentication);
            Context.SaveChanges();
        }
        public void DeleteUser(int id)
        {
            Context.UserAuthentications.Remove(new UserAuthentication() { UsernameId = id });
            Context.SaveChanges();
        }
        public UserAuthentication UserProfile(int id)
        {
            return Context.UserAuthentications.Find(id);
        }
    }
}
