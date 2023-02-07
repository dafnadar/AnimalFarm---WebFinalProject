namespace MosesFarmTests
{
    [TestClass]
    public class AdminRepTests
    {

        [TestMethod]
        public void GetAdminsTest()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddTransient<IAdminRepository, AdminRepository>();
            builder.Services.AddDbContext<AnimalContext>(options => options.UseSqlServer("Server=(localdb)\\MosesFarmDb;Database=AnimalDbTest;Trusted_Connection=True;"));
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var adminRep = scope.ServiceProvider.GetRequiredService<IAdminRepository>();

                Assert.IsTrue(adminRep.GetAdmins().Count()==2);
            }
        }

        [TestMethod]
        public void InsertAnimalTest()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddTransient<IAdminRepository, AdminRepository>();
            builder.Services.AddDbContext<AnimalContext>(options => options.UseSqlServer("Server=(localdb)\\MosesFarmDb;Database=AnimalDbTest;Trusted_Connection=True;"));
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var adminRep = scope.ServiceProvider.GetRequiredService<IAdminRepository>();

                Animal animalToAdd = new Animal { Type = "Cat", Name = "Hachu", Age = 6, CategoryId=1 };
                adminRep.InsertAnimal(animalToAdd);
                Assert.IsTrue(ctx.Animals!.Contains(animalToAdd));
            }
        }

        [TestMethod]
        public void UpdateAnimalTest()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddTransient<IAdminRepository, AdminRepository>();
            builder.Services.AddDbContext<AnimalContext>(options => options.UseSqlServer("Server=(localdb)\\MosesFarmDb;Database=AnimalDbTest;Trusted_Connection=True;"));
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var adminRep = scope.ServiceProvider.GetRequiredService<IAdminRepository>();

                Animal animalToUpdate = new Animal { Id = 3, Type = "Cat", Name = "Freddie", Age = 10, Description = "I love freddie", CategoryId=1 };
                adminRep.UpdateAnimal(animalToUpdate);
                Assert.IsTrue(animalToUpdate.Age == 10 && animalToUpdate.Description != default);
            }
        }

        [TestMethod]
        public void DeleteAnimalTest()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddTransient<IAdminRepository, AdminRepository>();
            builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
            builder.Services.AddDbContext<AnimalContext>(options => options.UseSqlServer("Server=(localdb)\\MosesFarmDb;Database=AnimalDbTest;Trusted_Connection=True;"));
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var adminRep = scope.ServiceProvider.GetRequiredService<IAdminRepository>();
                var animalRep = scope.ServiceProvider.GetRequiredService<IAnimalRepository>();

                Animal animalToDelete = animalRep.GetAllAnimals()!.Where(m => m.Id == 1).First();
                adminRep.DeleteAnimal(animalToDelete);
                Assert.IsFalse(ctx.Animals!.Contains(animalToDelete));
            }
        }

        [TestMethod]
        public void AddCategoryTest()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddTransient<IAdminRepository, AdminRepository>();
            builder.Services.AddDbContext<AnimalContext>(options => options.UseSqlServer("Server=(localdb)\\MosesFarmDb;Database=AnimalDbTest;Trusted_Connection=True;"));
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var adminRep = scope.ServiceProvider.GetRequiredService<IAdminRepository>();

                adminRep.AddCategory(new Category { Name = "Wild"});
                Assert.IsTrue(ctx.Categories!.Any(c=>c.Name=="Wild"));
            }
        }

        [TestMethod]
        public void UpdateCategory()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddTransient<IAdminRepository, AdminRepository>();
            builder.Services.AddDbContext<AnimalContext>(options => options.UseSqlServer("Server=(localdb)\\MosesFarmDb;Database=AnimalDbTest;Trusted_Connection=True;"));
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var adminRep = scope.ServiceProvider.GetRequiredService<IAdminRepository>();

                Category category = ctx.Categories!.First(c => c.Id == 1);
                string categoryName = category.Name!;
                category.Name = "Wild";
                adminRep.UpdateCategory(category);
                Assert.IsFalse(ctx.Categories!.Any(c=>c.Name==categoryName));
            }
        }

        [TestMethod]
        public void DeleteCategory()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddTransient<IAdminRepository, AdminRepository>();
            builder.Services.AddDbContext<AnimalContext>(options => options.UseSqlServer("Server=(localdb)\\MosesFarmDb;Database=AnimalDbTest;Trusted_Connection=True;"));
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var adminRep = scope.ServiceProvider.GetRequiredService<IAdminRepository>();

                Category category = ctx.Categories!.First(c => c.Id == 1);
                adminRep.DeleteCategory(category);
                Assert.IsFalse(ctx.Categories!.Contains(category));
            }
        }
    }
}
