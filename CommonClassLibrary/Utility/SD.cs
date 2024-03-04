namespace  CommonClassLibrary.Dto
{
    //Static Details
    public class SD 
    {
        public static string AuthAPIBase { get; set; }
        public const string RoleAdmin = "ADMIN";
        public const string RoleCustomer = "CUSTOMER";
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
