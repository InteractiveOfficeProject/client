namespace InteractiveOfficeClient.Models
{
    public class BreakSeekerRequest
    {
    	readonly int BreakID;
    	readonly User User;
    	readonly string Joined;
    	readonly Activity[] Activities;
    	readonly string Status;

        public BreakSeekerRequest(int breakId, User user, string joined, Activity[] activities, string status)
        {
            BreakID = breakId;
            User = user;
            Joined = joined;
            Activities = activities;
            Status = status;
        }
    }
}