using Microsoft.AspNetCore.Mvc;
using NewsWeb.Core.Entities;
using NewsWeb.Infrustructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsWeb.AdsViewComponents
{
    public class AdsViewComponent : ViewComponent
    {
        AdsRepository adsRepository;
        public AdsViewComponent()
        {
            adsRepository = new AdsRepository();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Ads> model = adsRepository.GetAds();
            return View(model);
        }
    }
}
