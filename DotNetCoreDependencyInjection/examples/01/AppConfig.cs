namespace DotNetDependencyInjection.examples._01
{
    public class AppConfig
    {
        public string Property_1 { get; set; }
        public string Property_2 { get; set; }
        public string Property_3 { get; set; }
        public Suite Suite { get; set; }
    }

    public class Suite
    {
        public string Comment { get; set; }
    }
}