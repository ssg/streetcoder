using Blabber.Models;
using System.Linq;
using System.Web.Mvc;

namespace Blabber.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(BlabStorage storage)
        {
            this.storage = storage;
        }

        private static readonly HomepageModel defaultHomepageModel = new HomepageModel
        {
            Blabs = Enumerable.Empty<Blab>(),
            Form = new BlabForm()
            {
                Content = null,
            }
        };

        private readonly BlabStorage storage;

        public ActionResult Index()
        {
            var model = defaultHomepageModel;
            model.Blabs = storage.GetAllBlabs();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}