namespace Xamarin.Forms.Sandbox.UWP
{
	public sealed partial class MainPage
	{
		public MainPage()
		{
			InitializeComponent();

			LoadApplication(Sandbox.App.GetApplication());
		}
	}
}
