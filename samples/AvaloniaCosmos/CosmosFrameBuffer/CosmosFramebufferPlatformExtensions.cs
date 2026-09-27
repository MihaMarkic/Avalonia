using Avalonia;
using Avalonia.Controls;

namespace CosmosFrameBuffer;

public static class CosmosFramebufferPlatformExtensions
{
	public static int StartCosmosDirect(this AppBuilder builder, string[] args)
	{
		var lifetime = CosmosFramebufferPlatform.Initialize(builder);
		builder.SetupWithLifetime(lifetime);
		lifetime.Start(args);
		builder.Instance!.Run(lifetime.Token);
		return lifetime.ExitCode;
	}
}