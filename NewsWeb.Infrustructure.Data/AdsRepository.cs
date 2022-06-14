using NewsWeb.Core.Entities;
using NewsWeb.Infraustraucture.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsWeb.Infrustructure.Data
{
    public class AdsRepository
    {
        private readonly MyContext Context;
        public AdsRepository()
        {
            Context = new MyContext();
        }
        public List<Ads> GetAds()
        {
            return Context.Ads.ToList();
        }
    }
}
