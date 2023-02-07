namespace MozesFarmWebsite.Repositories
{
    public interface IAdminRepository
    {
        public void DeleteAnimal(Animal animal);
        public void InsertAnimal(Animal animal);
        public void UpdateAnimal(Animal animal);
        public IEnumerable<Admin> GetAdmins();
        public void AddCategory(Category category);
        public void UpdateCategory(Category category);
        public void DeleteCategory(Category category);
    }
}
