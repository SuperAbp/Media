using System;
using System.Reflection.Metadata;
using Volo.Abp.DependencyInjection;

namespace SuperAbp.Media;

public class MediaTestData : ISingletonDependency
{
    public Guid Media1Id { get; } = Guid.NewGuid();

    public string Media1Content { get; } = "Hi, this is text file";

    public string Media1Name { get; } = "hello.txt";

    public string Media1ContentType { get; } = "text/plain";
}