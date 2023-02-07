namespace MozesFarmWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnimalController : Controller
    {
        private readonly IAdminRepository _adminRep;
        private readonly IAnimalRepository _animalRep;
        private readonly IWebHostEnvironment _webHost;

        public AnimalController(IAdminRepository repository, IAnimalRepository animalRep, IWebHostEnvironment webHost)
        {
            _adminRep = repository;
            _animalRep = animalRep;
            _webHost = webHost;
        }

        public IActionResult Index()
        {
            var animalContext = _animalRep.GetAllAnimals();
            return View(animalContext);
        }

        public IActionResult Details(int? id)
        {
            if (id == null || _animalRep.GetAllAnimals() == null)
            {
                return NotFound();
            }

            var animal = _animalRep.GetAllAnimals().FirstOrDefault(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        public IActionResult Create()
        {
            ViewBag.CategoryNames = new SelectList(_animalRep.GetCategories(), "Id", "Name");      
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Type,Name,Age,PictureInfo,Description,CategoryId")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                if (animal.PictureInfo != null)
                {
                    string folder = "images/";
                    string pictureName = Guid.NewGuid().ToString() + animal.PictureInfo.FileName;
                    animal.PictureName = pictureName;
                    folder += pictureName;
                    string UrlPic = Path.Combine(_webHost.WebRootPath, folder);
                    animal.PictureInfo.CopyTo(new FileStream(UrlPic, FileMode.Create));
                }                
                _adminRep.InsertAnimal(animal);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoryNames = new SelectList(_animalRep.GetCategories(), "Id", "Name");
            return View(animal);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || _animalRep.GetAllAnimals() == null)
            {
                return NotFound();
            }

            var animal = _animalRep.GetAnimalById((int)id);
            if (animal == null)
            {
                return NotFound();
            }
            ViewBag.CategoryNames = new SelectList(_animalRep.GetCategories(), "Id", "Name");
            return View(animal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Type,Name,Age,PictureName, PictureInfo, Description,CategoryId")] Animal animal)
        {
            if (id != animal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (animal.PictureInfo != null)
                {
                    string folder = "images/";
                    string pictureName = Guid.NewGuid().ToString() + animal.PictureInfo.FileName;
                    animal.PictureName = pictureName;
                    folder += pictureName;
                    string UrlPic = Path.Combine(_webHost.WebRootPath, folder);
                    animal.PictureInfo.CopyTo(new FileStream(UrlPic, FileMode.Create));
                }                    

                try
                {
                    _adminRep.UpdateAnimal(animal);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(animal);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || _animalRep.GetAllAnimals() == null)
            {
                return NotFound();
            }

            var animal = _animalRep.GetAllAnimals().FirstOrDefault(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_animalRep.GetAllAnimals() == null)
            {
                return Problem("Entity set 'AnimalContext.Animals'  is null.");
            }
            var animal = _animalRep.GetAllAnimals().Single(c => c.Id == id);
            if (animal != null)
            {
                _adminRep.DeleteAnimal(animal);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(int id)
        {
            return (_animalRep.GetAllAnimals()?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
