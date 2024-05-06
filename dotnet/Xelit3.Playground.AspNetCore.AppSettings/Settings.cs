namespace Xelit3.Playground.AspNetCore.AppSettings
{
    public class Settings
    {
        public ExternalApiSettings ExternalApiSettings { get; set; }
    }


    public class ExternalApiSettings
    {
        public string EndpointUrl  { get; set; }
        public string Token { get; set; }
    }
}
