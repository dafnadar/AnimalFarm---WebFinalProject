namespace MozesFarmWebsite.Data
{
    public class AnimalContext : DbContext
    {
        public AnimalContext(DbContextOptions<AnimalContext> options)
            : base(options) { }        
        
        public virtual DbSet<Animal>? Animals { get; set; }
        public virtual DbSet<Comment>? Comments { get; set; }
        public virtual DbSet<Category>? Categories { get; set; }
        public virtual DbSet<User>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Admin>().HasData(
                new { Id = 1, UserName = "Rachel", Password = "1234", AdminNumber = 12 },
                new { Id = 2, UserName = "Dafna", Password = "1234", AdminNumber = 7 }
            );

            modelBuilder.Entity<User>().HasData(
                new { Id = 3, UserName = "First", Password = "1111" },
                new { Id = 4, UserName = "Second", Password = "2222" }
            );

            modelBuilder.Entity<Animal>().HasData(
                new { Id = 1, Type = "Dog", Name = "Jesica", Age = 1, CategoryId = 1, PictureName = "Dog-Jesica.jpg", Description = "female.. bla.. bla.." },
                new { Id = 2, Type = "Dog", Name = "Bob", Age = 4, CategoryId = 1, PictureName = "Dog-Bob.jpg", Description = "male.. bla.. bla.." },
                new { Id = 3, Type = "Cat", Name = "Freddie", Age = 10, CategoryId = 1, PictureName = "Cat-Freddie.jpg", Description = "male.. bla.. bla.." },
                new { Id = 4, Type = "Cat", Name = "Sami", Age = 6, CategoryId = 1, PictureName = "Cat-Sami.jpg", Description = "male.. bla.. bla.." },


                new { Id = 5, Type = "Rooster", Name = "Rafa", Age = 2, CategoryId = 2, PictureName = "Rooster-Rafa.jpg", Description = "male.. bla.. bla.." },
                new { Id = 6, Type = "Rooster", Name = "Rona", Age = 5, CategoryId = 2, PictureName = "Rooster-Rona.jpg", Description = "female.. bla.. bla.." },
                new { Id = 7, Type = "Peacock", Name = "Pini", Age = 3, CategoryId = 2, PictureName = "Peacock-Pini.jpg", Description = "male.. bla.. bla.." },
                new { Id = 8, Type = "Peacock", Name = "Pnina", Age = 3, CategoryId = 2, PictureName = "Peacock-Pnina.jpg", Description = "female.. bla.. bla.." },

                new { Id = 9, Type = "Cow", Name = "Moo", Age = 5, CategoryId = 3, PictureName = "Cow-Moo.jpg", Description = "male.. bla.. bla.." },
                new { Id = 10, Type = "Cow", Name = "Batya", Age = 4, CategoryId = 3, PictureName = "Cow-Batya.jpg", Description = "female.. bla.. bla.." },
                new { Id = 11, Type = "Sheep", Name = "Shoshi", Age = 7, CategoryId = 3, PictureName = "Sheep-Shoshi.jpg", Description = "female.. bla.. bla.." },
                new { Id = 12, Type = "Goat", Name = "Gita", Age = 6, CategoryId = 3, PictureName = "Goat-Gita.jpg", Description = "female.. bla.. bla.." },

                new { Id = 13, Type = "Rabbit", Name = "Roger", Age = 1, CategoryId = 4, PictureName = "Rabbit-Roger.jpg", Description = "male.. bla.. bla.." },
                new { Id = 14, Type = "Rabbit", Name = "Batya", Age = 2, CategoryId = 4, PictureName = "Rabbit-Lisa.jpg", Description = "female.. bla.. bla.." },
                new { Id = 15, Type = "Guinea Pig", Name = "Shrek", Age = 3, CategoryId = 4, PictureName = "Guinea Pig-Shrek.jpg", Description = "male.. bla.. bla.." },
                new { Id = 16, Type = "Guinea Pig", Name = "Shula", Age = 4, CategoryId = 4, PictureName = "Guinea Pig-Shula.jpg", Description = "female.. bla.. bla.." }

            ); 

            modelBuilder.Entity<Category>().HasData(
                new { Id = 1, Name = "Pet" },
                new { Id = 2, Name = "Bird" },
                new { Id = 3, Name = "Cattle" },
                new { Id = 4, Name = "Petting Zoo" }
            );

            modelBuilder.Entity<Comment>().HasData(
                new { Id = 1, WriterName = "Rachel", Date=DateTime.Now, CommentText = "bla..bla..", AnimalId = 5, CategoryId = 2 },
                new { Id = 2, WriterName = "Zohar", Date = DateTime.Now, CommentText = "bla..bla..", AnimalId = 2, CategoryId = 1 },
                new { Id = 3, WriterName = "Zohar", Date = DateTime.Now, CommentText = "Moooooo to you too", AnimalId = 9, CategoryId = 3 },
                new { Id = 4, WriterName = "Zohar", Date = DateTime.Now, CommentText = "bla..bla..", AnimalId = 9, CategoryId = 3 },
                new { Id = 5, WriterName = "Zohar", Date = DateTime.Now, CommentText = "bla..bla..", AnimalId = 2, CategoryId = 1 },
                new { Id = 6, WriterName = "Zohar", Date = DateTime.Now, CommentText = "soo preety", AnimalId = 9, CategoryId = 3 },
                new { Id = 7, WriterName = "Zohar", Date = DateTime.Now, CommentText = "bla..bla..", AnimalId = 5, CategoryId = 2 },
                new { Id = 8, WriterName = "Ofir", Date = DateTime.Now, CommentText = "bla..bla..", AnimalId = 2, CategoryId = 1 }
            );
        }
    }
}