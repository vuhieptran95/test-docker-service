namespace TestDocker.Controllers
{
    public class AppSettings
    {
        public static ConnectionString ConnectionStrings { get; set; }
        
        public class ConnectionString
        {
            public string ApexRegistration { get; set; }
        }
    }
}