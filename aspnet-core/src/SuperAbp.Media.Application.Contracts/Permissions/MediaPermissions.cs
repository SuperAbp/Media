using Volo.Abp.Reflection;

namespace SuperAbp.Media.Permissions;

public class MediaPermissions
{
    public const string GroupName = "Media";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(MediaPermissions));
    }
}
