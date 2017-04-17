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