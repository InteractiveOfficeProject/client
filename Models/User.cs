namespace InteractiveOfficeClient.Models
{
    public class User
    {
    	readonly int UserID;
    	readonly string Email;
    	readonly string Password;
    	readonly string FirstName;
    	readonly string LastName;
    	readonly string ProfilePictureURL;

        public static readonly User[] DefaultUsers = new User[]
        {
            new User(-1, "jan@iop.com", null, "Jan", "Lippert", "https://scontent-arn2-1.xx.fbcdn.net/v/t1.0-1/p160x160/18010738_1330465343685499_8300634623889550780_n.jpg?oh=3283af6717147bc8650eafcb2a8074b2&oe=5980EC79"),
            new User(-2, "peter@iop.com", null, "Péter", "Ivanics", "https://scontent-arn2-1.xx.fbcdn.net/v/t1.0-1/p160x160/17884548_1405089239513438_4902676495998571570_n.jpg?oh=ba601dc48d4722333acc2caf1d46ff6b&oe=59C23CAE"),
            new User(-3, "michael@iop.com", null, "Michael", "Morrasch","https://scontent-arn2-1.xx.fbcdn.net/v/t1.0-1/p100x100/17952895_1341257045920873_3010749970521346658_n.jpg?oh=9129cdef16fded85341fe3057c23b18d&oe=5983D42F"),
        };
        public User(int userId, string email, string password, string firstName, string lastName, string profilePictureUrl)
        {
            UserID = userId;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            ProfilePictureURL = profilePictureUrl;
        }
    }
}