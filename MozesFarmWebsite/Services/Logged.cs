namespace MozesFarmWebsite.Services
{
    public class Logged : ILogged
    {
        private bool isLogged { get; set; }
        private User? loggedUser { get; set; }

        public bool LoginStatus() => isLogged;
        public void Login(User user)
        {
            isLogged = true;
            loggedUser = user;
        }
        public void Logout()
        {
            isLogged = false;
            loggedUser = default;
        }
        public string GetLoggerName()
        {
            if (loggedUser == null) return "";
            return loggedUser!.UserName!;
        }
    }
}
