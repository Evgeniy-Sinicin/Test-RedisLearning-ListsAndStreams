public class AppOptions
{
    public required RoutingOptions Routing { get; init; }
    public required RedisOptions Redis { get; init; }

    public class RoutingOptions
    {
        public const string SectionName = "Routing";

        public required string Name { get; init; }
        public required string Pattern { get; init; }
        public required string Controller { get; init; }
        public object Defaults => new { controller = Controller };
    }

    public class RedisOptions
    {
        public const string SectionName = "Redis";

        public required string Address { get; init; }
        public required string ListKey { get; init; }
    }
}