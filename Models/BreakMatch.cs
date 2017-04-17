namespace InteractiveOfficeClient.Models
{
    public class BreakMatch
    {
    	readonly User[] Partners;
    	readonly Activity Activity;
    	readonly Room Room;
    	readonly string Timestamp;

        public BreakMatch(User[] partners, Activity activity, Room room, string timestamp)
        {
            Partners = partners;
            Activity = activity;
            Room = room;
            Timestamp = timestamp;
        }
    }
}