using Microsoft.AspNetCore.Mvc;
using NewsWeb.Core.Contracts;
using NewsWeb.Core.Entities;
using NewsWeb.Infrustructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsWeb.AdsViewComponents
{
    public class AdsViewComponent : ViewComponent
    {
        IAdsRepository adsRepository;
        public AdsViewComponent(IAdsRepository adsRepository)
        {
            this.adsRepository = adsRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Ads> model = adsRepository.GetAds();
            return View(model);
        }
    }
}
