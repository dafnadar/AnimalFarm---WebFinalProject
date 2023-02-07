namespace MozesFarmWebsite.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly AnimalContext _context;   
        public IdentityRepository(AnimalContext Context)
        {
            _context = Context;
        }

        public bool CheckIfUserExists(User user, out User dbUser)
        {
            dbUser = _context.Users
                .FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
            return dbUser == default ? false : true;
        }

        public bool IsAdmin(User user) => user.GetType().Name == "AdminProxy";

        public bool UsernameExists(string username) => _context.Users!.Any(u => u.UserName == username);

        public void AddUser(User user)
        {
            _context.Users!.Add(user);
            _context.SaveChanges();
        }
    }
}
