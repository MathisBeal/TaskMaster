namespace TaskManagerApp;

public partial class MainPage : ContentPage
{
	// int count = 0;
	//
	// public MainPage()
	// {
	// 	InitializeComponent();
	// }
	//
	// private void OnCounterClicked(object sender, EventArgs e)
	// {
	// 	count++;
	//
	// 	if (count == 1)
	// 		CounterBtn.Text = $"Clicked {count} time";
	// 	else
	// 		CounterBtn.Text = $"Clicked {count} times";
	//
	// 	SemanticScreenReader.Announce(CounterBtn.Text);
	// }

	private readonly UserService _userService;
	public MainPage(UserService userService)
	{
		InitializeComponent();
		_userService = userService;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		var users = await _userService.ObtenirUtilisateursAsync();
		listeUtilisateurs.ItemsSource = users;
	}
}

