namespace MozezFarmTests
{
    [TestClass]
    public class AnimalRepTests
    {

        [TestMethod]
        public void GetAllAnimalTest()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
            builder.Services.AddDbContext<AnimalContext>(options => options.UseSqlServer("Server=(localdb)\\MosesFarmDb;Database=AnimalDbTest;Trusted_Connection=True;"));
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var rep = scope.ServiceProvider.GetRequiredService<IAnimalRepository>();
                Assert.IsNotNull(rep.GetAllAnimals());
            }
        }

        [TestMethod]
        public void GetCategoriesTest()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
            builder.Services.AddDbContext<AnimalContext>(options => options.UseSqlServer("Server=(localdb)\\MosesFarmDb;Database=AnimalDbTest;Trusted_Connection=True;"));
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var rep = scope.ServiceProvider.GetRequiredService<IAnimalRepository>();

                Assert.IsTrue(rep.GetCategories().Count() == 4);
            }
        }

        [TestMethod]
        public void GetAnimalsByCategoryTest()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
            builder.Services.AddDbContext<AnimalContext>(options => options.UseSqlServer("Server=(localdb)\\MosesFarmDb;Database=AnimalDbTest;Trusted_Connection=True;"));
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var rep = scope.ServiceProvider.GetRequiredService<IAnimalRepository>();
                Assert.IsTrue(rep.GetAnimalsByCategory(1).Count() == 4);
            }
        }

        [TestMethod]
        public void GetAnimalByIdTest()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
            builder.Services.AddDbContext<AnimalContext>(options => options.UseSqlServer("Server=(localdb)\\MosesFarmDb;Database=AnimalDbTest;Trusted_Connection=True;"));
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var rep = scope.ServiceProvider.GetRequiredService<IAnimalRepository>();
                Assert.IsTrue(rep.GetAnimalById(2).Name == "Bob");
            }
        }

        [TestMethod]
        public void AddCommentTest()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
            builder.Services.AddDbContext<AnimalContext>(options => options.UseSqlServer("Server=(localdb)\\MosesFarmDb;Database=AnimalDbTest;Trusted_Connection=True;"));
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var rep = scope.ServiceProvider.GetRequiredService<IAnimalRepository>();

                Comment testComment = new Comment { CommentText = "tets", WriterName = "test" };
                int numComments = ctx.Comments!.Where(c => c.AnimalId == 2).Count();
                rep.AddComment(testComment, 2);
                Assert.IsTrue(ctx.Comments!.Where(c => c.AnimalId == 2).Count() == numComments + 1);
            }
        }

        [TestMethod]
        public void GetCommentsTest()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
            builder.Services.AddDbContext<AnimalContext>(options => options.UseSqlServer("Server=(localdb)\\MosesFarmDb;Database=AnimalDbTest;Trusted_Connection=True;"));
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var rep = scope.ServiceProvider.GetRequiredService<IAnimalRepository>();

                Assert.IsTrue(rep.GetComments(5).Count() == 2);
            }
        }

        [TestMethod]
        public void GetTwoMostPopularTest()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
            builder.Services.AddDbContext<AnimalContext>(options => options.UseSqlServer("Server=(localdb)\\MosesFarmDb;Database=AnimalDbTest;Trusted_Connection=True;"));
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var rep = scope.ServiceProvider.GetRequiredService<IAnimalRepository>();
                Assert.IsNotNull(rep.GetTwoMostPopular());
            }
        }
    }
}
