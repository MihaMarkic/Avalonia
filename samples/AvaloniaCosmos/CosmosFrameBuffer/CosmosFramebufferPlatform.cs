using Avalonia;
using Avalonia.Input;
using Avalonia.Input.Platform;
using Avalonia.Platform;
using Avalonia.Rendering;
using Avalonia.Rendering.Composition;

namespace CosmosFrameBuffer;

public class CosmosFramebufferPlatform
{
	internal static Compositor Compositor { get; private set; } = null!;
	
	void Initialize()
	{
		// if (_fb is IGlOutputBackend gl)
		// 	AvaloniaLocator.CurrentMutable.Bind<IPlatformGraphics>().ToConstant(gl.PlatformGraphics);

		// var opts = AvaloniaLocator.Current.GetService<LinuxFramebufferPlatformOptions>() ?? new LinuxFramebufferPlatformOptions();

		// var timer = opts.ShouldRenderOnUIThread
		// 	? new UiThreadRenderTimer(opts.Fps)
		// 	: new DefaultRenderTimer(opts.Fps);

		var timer = new UiThreadRenderTimer(60);
            
		// Dispatcher.InitializeUIThreadDispatcher(new EpollDispatcherImpl(new ManualRawEventGrouperDispatchQueueDispatcherInputProvider(EventGrouperDispatchQueue)));
		AvaloniaLocator.CurrentMutable
			.Bind<IRenderLoop>().ToConstant(RenderLoop.FromTimer(timer))
			.Bind<ICursorFactory>().ToTransient<CursorFactoryStub>()
			.Bind<IKeyboardDevice>().ToConstant(new KeyboardDevice())
			.Bind<IPlatformIconLoader>().ToSingleton<LinuxFramebufferIconLoaderStub>()
			.Bind<IPlatformSettings>().ToSingleton<DefaultPlatformSettings>()
			.Bind<PlatformHotkeyConfiguration>().ToSingleton<PlatformHotkeyConfiguration>()
			.Bind<KeyGestureFormatInfo>().ToConstant(new KeyGestureFormatInfo(new Dictionary<Key, string>() { }, meta: "Super"));
            
		Compositor = new Compositor(AvaloniaLocator.Current.GetService<IPlatformGraphics>());
	}
	internal static CosmosFramebufferLifetime Initialize(AppBuilder builder) // , IOutputBackend outputBackend, IInputBackend? inputBackend
	{
		var platform = new CosmosFramebufferPlatform();
		builder
			.UseStandardRuntimePlatformSubsystem()
			.UseCosmos()
			.UseWindowingSubsystem(platform.Initialize, "fbdev");
		return new CosmosFramebufferLifetime();
	}
}