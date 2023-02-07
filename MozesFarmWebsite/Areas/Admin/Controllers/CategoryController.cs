namespace MozesFarmWebsite.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IAdminRepository _adminRep;
        private readonly IAnimalRepository _animalRep;

        public CategoryController(IAdminRepository repository, IAnimalRepository animalRep)
        {
            _adminRep = repository;
            _animalRep = animalRep;
        }

        public IActionResult Index()
        {
            return View(_animalRep.GetCategories());
        }

        public IActionResult Details(int? id)
        {
            if (id == null || _animalRep.GetCategories() == null)
            {
                return NotFound();
            }

            var category = _animalRep.GetCategories()
                .FirstOrDefault(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                _adminRep.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || _animalRep.GetCategories() == null)
            {
                return NotFound();
            }

            var category = _animalRep.GetCategories().Single(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _adminRep.UpdateCategory(category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
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
            return View(category);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || _animalRep.GetCategories() == null)
            {
                return NotFound();
            }

            var category = _animalRep.GetCategories()
                .FirstOrDefault(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_animalRep.GetCategories() == null)
            {
                return Problem("Entity set 'AnimalContext.Categories'  is null.");
            }
            var category = _animalRep.GetCategories().Single(c => c.Id == id);
            if (category != null)
            {
                _adminRep.DeleteCategory(category);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return (_animalRep.GetCategories()?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

