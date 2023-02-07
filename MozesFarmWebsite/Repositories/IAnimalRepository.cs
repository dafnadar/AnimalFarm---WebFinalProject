namespace WebProject.Repositories
{
    public interface IAnimalRepository
    {
        public IEnumerable<Category> GetCategories();
        IEnumerable<Animal> GetAllAnimals();
        public Animal GetAnimalById(int id);
        public IEnumerable<Animal> GetAnimalsByCategory(int categoryId);
        public void AddComment(Comment comment, int animalId);
        public IEnumerable<Comment> GetComments(int animalId);
        public IEnumerable<Animal> GetTwoMostPopular();
    }
}
