namespace InteractiveOfficeClient.Models
{
    public class Activity
    {
        public readonly int ActivityID;
        public readonly string Name;
        public  readonly int MaximumUsers;

        public static readonly Activity[] DefaultActivities = new Activity[]
        {
            new Activity(-1, "Coffee Break", 0),
            new Activity(-2, "Walking", 0),
            new Activity(-3, "Play a Game", 0),
            new Activity(-4, "Sing a Song", 0)
        };

        public Activity(int activityId, string name, int maximumUsers)
        {
            ActivityID = activityId;
            Name = name;
            MaximumUsers = maximumUsers;
        }

        public override string ToString()
        {
            return $"[{ActivityID} - {Name} ({MaximumUsers})]";
        }
    }
}