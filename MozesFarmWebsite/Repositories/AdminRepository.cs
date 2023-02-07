namespace MozesFarmWebsite.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private AnimalContext _context;

        public AdminRepository(AnimalContext context)
        {
            _context = context;
        }

        public IEnumerable<Admin> GetAdmins() => _context.Users!.OfType<Admin>();

        //CRUD-Animal
        public void InsertAnimal(Animal animal)
        {
            _context.Animals!.Add(animal);
            _context.SaveChanges();
        }

        public void UpdateAnimal(Animal animal)
        {
            _context.Update(animal);
            _context.SaveChanges();
        }

        public void DeleteAnimal(Animal animal)
        {
            _context.Animals?.Remove(animal);
            _context.SaveChanges();
        }

        //CRUD-Categories
        public void AddCategory(Category category)
        {
            _context.Categories!.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Update(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories!.Remove(category);
            _context.SaveChanges();
        }

    }
}
