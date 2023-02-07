namespace MozezFarmTests
{
    [TestClass]
    public class IdentityRepTest
    {
        [TestMethod]
        public void CheckIfUserExistsTests()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddTransient<IIdentityRepository, IdentityRepository>();
            builder.Services.AddDbContext<AnimalContext>(options => options.UseSqlServer("Server=(localdb)\\MosesFarmDb;Database=AnimalDbTest;Trusted_Connection=True;"));
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var rep = scope.ServiceProvider.GetRequiredService<IIdentityRepository>();

                User user = ctx.Users!.First(u=>u.Id==1);
                Assert.IsTrue(rep.CheckIfUserExists(user, out User user1));
            }
        }

        [TestMethod]
        public void IsAdminTest()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddTransient<IIdentityRepository, IdentityRepository>();
            builder.Services.AddDbContext<AnimalContext>(options => options.UseSqlServer("Server=(localdb)\\MosesFarmDb;Database=AnimalDbTest;Trusted_Connection=True;"));
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var rep = scope.ServiceProvider.GetRequiredService<IIdentityRepository>();

                User user = new User { Password = "1234", UserName = "Rachel" };
                rep.CheckIfUserExists(user, out User dbUser);
                Assert.IsFalse(rep.IsAdmin(dbUser));
            }
        }

        [TestMethod]
        public void UsernameExistsTest()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddTransient<IIdentityRepository, IdentityRepository>();
            builder.Services.AddDbContext<AnimalContext>(options => options.UseSqlServer("Server=(localdb)\\MosesFarmDb;Database=AnimalDbTest;Trusted_Connection=True;"));
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var rep = scope.ServiceProvider.GetRequiredService<IIdentityRepository>();

                User user = new User { Password = "1234", UserName = "Rachel" };
                Assert.IsTrue(rep.UsernameExists(user.UserName));
            }
        }

        [TestMethod]
        public void AddUserTest()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddTransient<IIdentityRepository, IdentityRepository>();
            builder.Services.AddDbContext<AnimalContext>(options => options.UseSqlServer("Server=(localdb)\\MosesFarmDb;Database=AnimalDbTest;Trusted_Connection=True;"));
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var rep = scope.ServiceProvider.GetRequiredService<IIdentityRepository>();

                User user = new User { Password = "1234", UserName = "Ofir" };
                rep.AddUser(user);
                Assert.IsTrue(ctx.Users!.Any(u=>u.UserName=="ofir"));
            }
        }
    }
}
