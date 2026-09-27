using System.Diagnostics.CodeAnalysis;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Embedding;
using Avalonia.Input;

namespace CosmosFrameBuffer;

public class CosmosFramebufferLifetime: IControlledApplicationLifetime, ISingleViewApplicationLifetime, ISingleTopLevelApplicationLifetime
{
	private readonly CancellationTokenSource _cts = new CancellationTokenSource();
	public CancellationToken Token => _cts.Token;
	
	public int ExitCode { get; private set; }
	
	public event EventHandler<ControlledApplicationLifetimeStartupEventArgs>? Startup;
	public event EventHandler<ControlledApplicationLifetimeExitEventArgs>? Exit;
	public Control? MainView { get; set; }
	private TopLevel? _topLevel;

	public TopLevel? TopLevel
	{
		get
		{
			if (_topLevel is null)
			{
				EnsureTopLevel();
			}

			return _topLevel;
		}
	}

	[MemberNotNull(nameof(_topLevel))]
	private void EnsureTopLevel()
	{
		// IInputBackend inputBackend; // = _inputBackend;
		// if (inputBackend == null)
		// {
		// 	if (Environment.GetEnvironmentVariable("AVALONIA_USE_EVDEV") == "1")
		// 		inputBackend = EvDevBackend.CreateFromEnvironment();
		// 	else
		// 		inputBackend = new LibInputBackend();
		// }

		var fb = new FramebufferToplevelImpl();
		var tl = new EmbeddableControlRoot(fb);
		tl.Prepare();
		tl.StartRendering();
		_topLevel = tl;

		if (_topLevel is IFocusScope scope && _topLevel.FocusManager is FocusManager focusManager)
		{
			focusManager.SetFocusScope(scope);
		}
	}


	public void Shutdown(int exitCode = 0)
	{
		ExitCode = exitCode;
		var e = new ControlledApplicationLifetimeExitEventArgs(exitCode);
		Exit?.Invoke(this, e);
		ExitCode = e.ApplicationExitCode;
	}

	public void Start(string[] args)
	{
		Startup?.Invoke(this, new ControlledApplicationLifetimeStartupEventArgs(args));
	}
}