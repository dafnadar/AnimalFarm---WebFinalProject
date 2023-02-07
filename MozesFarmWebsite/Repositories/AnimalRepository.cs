namespace WebProject.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private AnimalContext _context;

        public AnimalRepository(AnimalContext context)
        {
            _context = context;
        }

        public IEnumerable<Animal> GetAllAnimals() => _context!.Animals!;

        public IEnumerable<Category> GetCategories() => _context.Categories!;

        public IEnumerable<Animal> GetAnimalsByCategory(int categoryId)
        {
            Category category = _context.Categories!.First(c => c.Id == categoryId);
            return _context.Animals!.Where(a => a.Category == category);
        }

        public Animal GetAnimalById(int id) => _context.Animals!.Single(a => a.Id == id);

        public void AddComment(Comment comment, int animalId)
        {
            var animal = GetAnimalById(animalId);
            comment.AnimalId = animalId;
            comment.Animal = animal;
            comment.Category = animal.Category;
            comment.CategoryId = animal.CategoryId;
            comment.Date = DateTime.Now;
            _context.Comments!.Add(comment);
            _context.SaveChanges();
        }

        public IEnumerable<Comment> GetComments(int animalId)
        {
            return _context.Comments!.Where(c => c.AnimalId == animalId).OrderByDescending(c => c.Date);
        }

        public IEnumerable<Animal> GetTwoMostPopular()
        {
            var animals = _context!.Animals!
                .OrderByDescending(a => a.Comments!.Count())
                .Take(2);
            return animals;
        }
    }
}
