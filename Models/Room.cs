namespace InteractiveOfficeClient.Models
{
    public class Room
    {
    	readonly int RoomID;
    	readonly string Name;
    	readonly int MaximumUsers;

        public Room(int roomId, string name, int maximumUsers)
        {
            RoomID = roomId;
            Name = name;
            MaximumUsers = maximumUsers;
        }
        public Room(int roomId, string name)
        {
            RoomID = roomId;
            Name = name;
            MaximumUsers = 0;
        }
    }
}