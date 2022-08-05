
namespace Studyrooms {
    public class Player
    {
        private static string email;
        private static string username;

        public Player(string newemail, string newusername)
        {
            email = newemail;
            username = newusername;
        }

        public string getEmail()
        {
            return email;
        }

        public string getUsername()
        {
            return username;
        }

    }
}