using NewsWeb.Core.Entities;
using System.Collections.Generic;

namespace NewsWeb.Core.Contracts
{
    public interface IAdsRepository
    {
        List<Ads> GetAds();
    }
}
