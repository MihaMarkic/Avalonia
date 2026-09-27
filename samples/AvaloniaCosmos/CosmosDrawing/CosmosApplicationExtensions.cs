using AvaloniaCosmos;

namespace Avalonia
{
    /// <summary>
    /// Skia application extensions.
    /// </summary>
    public static class CosmosApplicationExtensions
    {
        /// <summary>
        /// Enable Skia renderer.
        /// </summary>
        /// <param name="builder">Builder.</param>
        /// <returns>Configure builder.</returns>
        public static AppBuilder UseCosmos(this AppBuilder builder)
        {
            // builder = builder
            //     .UseHarfBuzz()
            //     .UseWayland();
            //
            return builder.UseRenderingSubsystem(CosmosPlatform.Initialize, "Cosmos");
        }
    }
}