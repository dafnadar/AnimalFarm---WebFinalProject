namespace MozesFarmWebsite.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IAdminRepository _adminRep;

        public HomeController(IAdminRepository repository)
        {
            _adminRep = repository;
        }
        public IActionResult Index(int id)
        {
            ViewBag.AdminName = _adminRep.GetAdmins().First(a => a.Id == id).UserName;
            return View();
        }
    }
}

