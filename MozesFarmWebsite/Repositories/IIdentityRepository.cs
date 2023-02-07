namespace MozesFarmWebsite.Repositories
{
    public interface IIdentityRepository
    {
        public bool CheckIfUserExists(User user, out User dbUser);
        public bool IsAdmin(User user);
        public bool UsernameExists(string username);
        public void AddUser(User user);
    }
}
