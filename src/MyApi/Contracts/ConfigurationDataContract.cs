namespace MyApi.Contracts
{
    /// <summary>
    /// A simple configuration data contract to show the configuration being used
    /// at present
    /// </summary>
    public class ConfigurationDataContract
    {
        public const string ConfigSection = "ConfigurationData";
        public string SomeConnectionString { get; set; }
        public bool AmFromTheAppSettingsFile { get; set; }

        public string SomeString { get; set; }

        public int SomeInt { get; set; }
    }
}