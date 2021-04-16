using Blabber.Models;
using System.Linq;
using System.Web.Mvc;

namespace Blabber.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlabStorage _storage;
        public HomeController(BlabStorage storage)
        {
            _storage = storage;
        }

        private static readonly HomepageModel _defaultHomepageModel = new HomepageModel
        {
            Blabs = Enumerable.Empty<Blab>(),
            Form = new BlabForm()
            {
                Content = null,
            }
        };

        public ActionResult Index()
        {
            var model = _defaultHomepageModel;
            model.Blabs = _storage.GetAllBlabs();
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