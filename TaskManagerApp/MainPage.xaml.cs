using System.Diagnostics;

namespace TaskManagerApp;

public partial class MainPage : ContentPage
{
	private readonly UserService _userService;
	public MainPage(UserService userService)
	{
		InitializeComponent();
		_userService = userService;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		Debug.WriteLine("OnAppearing called in MainPage");
		var users = await _userService.ObtenirUtilisateursAsync();
		Debug.WriteLine($"Number of users retrieved: {users.Count}");
		foreach (var user in users)
		{
			Debug.WriteLine($"User: {user.nom} {user.prenom}");
		}
		listeUtilisateurs.ItemsSource = users;
	}
}

