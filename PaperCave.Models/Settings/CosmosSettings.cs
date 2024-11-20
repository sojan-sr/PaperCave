namespace PaperCave.Models.Settings
{
    public class CosmosSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string PartitionKey { get; set; } = string.Empty;
    }
}
