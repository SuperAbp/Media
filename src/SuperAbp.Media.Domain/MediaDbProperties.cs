namespace SuperAbp.Media;

public static class MediaDbProperties
{
    public static string DbTablePrefix { get; set; } = "SuperAbp";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "SuperAbpMedia";
}
