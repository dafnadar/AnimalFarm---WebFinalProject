namespace MozesFarmWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnimalRepository _repository;

        public HomeController(IAnimalRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var animals = _repository.GetTwoMostPopular();            
            return View(animals);
        }

        public IActionResult Catalog()
        {
            ViewBag.Categories = _repository.GetCategories();
            var animals = _repository.GetAllAnimals();
            return View(animals);
        }

        [HttpPost]
        public IActionResult Catalog(int id)
        {            
            ViewBag.Categories = _repository.GetCategories();
            var animals = (id==0) ? _repository.GetAllAnimals() : _repository.GetAnimalsByCategory((int)id!);
            return View(animals);
        }

        [HttpGet]
        public IActionResult ShowAnimal(int id)
        {                        
            var animal = _repository.GetAnimalById(id); 
            ViewBag.Comments=_repository.GetComments(id);
            ViewBag.DemoComment = new Comment { AnimalId = animal.Id };
            ViewBag.Message = "Add Comment";
            return View(animal);
        }

        [HttpPost]
        public IActionResult ShowAnimal(Comment comment, int id)
        {
            ModelState.Clear();
            comment.Id = null;
            _repository.AddComment(comment, id);
            var animal = _repository.GetAnimalById(id);
            ViewBag.Comments = _repository.GetComments(id);
            ViewBag.DemoComment = new Comment { AnimalId = id };
            ViewBag.Message = "Add Another Comment";            
            return View("ShowAnimal", animal);
        }
    }
}