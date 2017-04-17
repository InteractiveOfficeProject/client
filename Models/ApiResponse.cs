namespace InteractiveOfficeClient.Models
{
    public class ApiResponse
    {
    	readonly int code;
    	readonly string type;
    	readonly string message;

        public ApiResponse(int code, string type, string message)
        {
            this.code = code;
            this.type = type;
            this.message = message;
        }
    }
}