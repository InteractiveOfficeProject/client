namespace InteractiveOfficeClient.Models
{
    public class Activity
    {
        readonly int ActivityID;
        readonly string Name;
        private readonly int MaximumUsers;


        public Activity(int activityId, string name, int maximumUsers)
        {
            ActivityID = activityId;
            Name = name;
            MaximumUsers = maximumUsers;
        }
    }
}