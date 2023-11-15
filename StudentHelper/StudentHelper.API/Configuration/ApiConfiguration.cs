namespace StudentHelper.API.Configuration
{
    public static class ApiConfiguration
    {
        public static string UserApiBase {  get; set; }

        public static string AuthApiBase {  get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT, 
            DELETE
        }
    }
}
