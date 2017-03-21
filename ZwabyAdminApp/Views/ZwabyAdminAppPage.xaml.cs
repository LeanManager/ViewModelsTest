using Xamarin.Forms;

namespace ZwabyAdminApp
{
	public partial class ZwabyAdminAppPage : ContentPage
	{
		public ZwabyAdminAppPage()
		{
			InitializeComponent();
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new ClockTestPage());
		}
	}
}
