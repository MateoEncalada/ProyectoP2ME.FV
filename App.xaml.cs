namespace ProyectoP2ME.FV;

public partial class App : Application
{
	public static InfoRepository InfoRepo { get; private set; }
	public App(InfoRepository repo)
	{
		InitializeComponent();

		MainPage = new AppShell();
		InfoRepo = repo;
	}
}
