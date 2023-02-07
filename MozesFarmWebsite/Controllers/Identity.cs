namespace MozesFarmWebsite.Controllers
{
    public class Identity : Controller
    {
        private readonly IIdentityRepository _repository;
        private readonly ILogged _loginControl;
        public Identity(IIdentityRepository repository, ILogged loginControl)
        {
            _repository = repository;
            _loginControl = loginControl;
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            return View();
        }
        
        [HttpPost]
        public IActionResult Register(User user, string returnUrl)
        {
            if (_repository.UsernameExists(user.UserName!))
            {
                ViewBag.Message = "Username already exists, try a different one";
                ViewBag.returnUrl = returnUrl;
                return View();
            }

            _repository.AddUser(user);
            _loginControl.Login(user);
            return Redirect(returnUrl);
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            return View();
        }

        [HttpPost]
        public IActionResult Login(User DemoUser, string returnUrl)
        {
            if (_repository.CheckIfUserExists(DemoUser, out User dbUser))
            {
                if (_repository.IsAdmin(dbUser))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin", @id = dbUser.Id });
                }
                else
                {
                    _loginControl.Login(dbUser);
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            ViewBag.Message = "username or password incorrect";
            return View();
        }

        public IActionResult Logout()
        {            
            _loginControl.Logout();
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
