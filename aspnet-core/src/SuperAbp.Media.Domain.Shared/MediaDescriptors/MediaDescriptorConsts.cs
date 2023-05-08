using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAbp.Media.MediaDescriptors
{
    public class MediaDescriptorConsts
    {
        public static int MaxNameLength { get; set; } = 255;

        public static int MaxMimeTypeLength { get; set; } = 128;

        public static int MaxHashLength { get; set; } = 50;

        public static int MaxSizeLength = int.MaxValue;
    }
}