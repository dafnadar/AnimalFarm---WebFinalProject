namespace MozesFarmWebsite.Services
{
    public interface ILogged
    {
        public bool LoginStatus();
        public void Login(User user);
        public void Logout();
        public string GetLoggerName();
    }
}
