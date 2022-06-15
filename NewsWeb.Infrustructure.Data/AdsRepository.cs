using NewsWeb.Core.Contracts;
using NewsWeb.Core.Entities;
using NewsWeb.Infraustraucture.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsWeb.Infrustructure.Data
{
    public class AdsRepository : IAdsRepository
    {
        private readonly MyContext Context;
        public AdsRepository(MyContext Context)
        {
            this.Context = Context;
        }
        public List<Ads> GetAds()
        {
            return Context.Ads.ToList();
        }
    }
}
