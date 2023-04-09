using Microsoft.EntityFrameworkCore;
using SuperAbp.Media.MediaDescriptors;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace SuperAbp.Media.EntityFrameworkCore;

public static class MediaDbContextModelCreatingExtensions
{
    public static void ConfigureMedia(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<MediaDescriptor>(b =>
        {
            b.ToTable(MediaDbProperties.DbTablePrefix + "MediaDescriptors", MediaDbProperties.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name).IsRequired().HasMaxLength(MediaDescriptorConsts.MaxNameLength);
            b.Property(x => x.MimeType).IsRequired().HasMaxLength(MediaDescriptorConsts.MaxMimeTypeLength);
            b.Property(x => x.Size).HasMaxLength(MediaDescriptorConsts.MaxSizeLength);
            b.Property(x => x.Hash).HasMaxLength(MediaDescriptorConsts.MaxHashLength);
            b.HasIndex(x => x.Name);
            b.HasIndex(x => x.Hash);
        });
    }
}