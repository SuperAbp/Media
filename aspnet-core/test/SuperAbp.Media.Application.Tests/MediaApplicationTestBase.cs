using System;
using SuperAbp.Media.EntityFrameworkCore;

namespace SuperAbp.Media;

public abstract class MediaApplicationTestBase : MediaTestBase<MediaApplicationTestModule>
{
    protected virtual void UsingDbContext(Action<IMediaDbContext> action)
    {
        using (var dbContext = GetRequiredService<IMediaDbContext>())
        {
            action.Invoke(dbContext);
        }
    }

    protected virtual T UsingDbContext<T>(Func<IMediaDbContext, T> action)
    {
        using (var dbContext = GetRequiredService<IMediaDbContext>())
        {
            return action.Invoke(dbContext);
        }
    }
}