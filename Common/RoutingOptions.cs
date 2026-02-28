public class RoutingOptions
{
    public const string SectionName = "Routing";

    public required string Name { get; set; }
    public required string Pattern { get; set; }
    public required string Controller { get; set; }
}