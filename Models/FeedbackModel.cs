namespace InteractiveOfficeClient.Models
{
    public class FeedbackModel
    {
    	readonly int FeedbackID;
    	readonly User User;
    	readonly User[] Partners;
    	readonly Activity[] Activities;
    	readonly Room Room;
    	readonly string Feedback;

        public FeedbackModel(int feedbackId, User user, User[] partners, Activity[] activities, Room room, string feedback)
        {
            FeedbackID = feedbackId;
            User = user;
            Partners = partners;
            Activities = activities;
            Room = room;
            Feedback = feedback;
        }
    }
}