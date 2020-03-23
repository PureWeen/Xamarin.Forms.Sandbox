using System.Windows.Input;

namespace Xamarin.Forms.Sandbox
{
    public class ShellViewModel
	{
		public ICommand OpenUrlCommand { get; }
		public ICommand OpenModalCommand { get; }

		public ShellViewModel()
		{
			OpenUrlCommand = new Command(async () =>
			{
				await Essentials.Launcher.TryOpenAsync(@"https://dotnetconf.net/Page?Id=12");
			});

			OpenModalCommand = new Command(async () =>
			{
				await Shell.Current.GoToAsync("ModalPage");
			});
		}
	}
}