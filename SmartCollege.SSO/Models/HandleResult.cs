namespace SmartCollege.SSO.Models
{
    public record HandleResult 
    {
        public int StatusCode { get; }
    
        public string Description { get; }

        private HandleResult(int statusCode, string desctiption)
        {
            StatusCode = statusCode;
            Description = desctiption;
        }

        public static HandleResult Success(int statusCode, string description)
        {
            return new HandleResult(statusCode, description);
        }

        public static HandleResult Failure(int statusCode, string description)
        {
            return new HandleResult(statusCode, description);
        }
    }
}
