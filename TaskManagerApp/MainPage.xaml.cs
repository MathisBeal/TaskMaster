using System.Diagnostics;

namespace TaskManagerApp;

public partial class MainPage : ContentPage
{
    private readonly UserService _userService;
    private bool isLoggedIn = false;

    public MainPage(UserService userService)
    {
        InitializeComponent();
        _userService = userService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        Debug.WriteLine("OnAppearing called in MainPage");

        if (isLoggedIn)
        {
            await ChargerUtilisateurs();
        }
        else
        {
            Debug.WriteLine("Veuillez vous connecter pour voir les utilisateurs.");
        }
    }

    private async Task ChargerUtilisateurs()
    {
        var users = await _userService.ObtenirUtilisateursAsync();
        Debug.WriteLine($"Number of users retrieved: {users.Count}");
        foreach (var user in users)
        {
            Debug.WriteLine($"User: {user.nom} {user.prenom}");
        }
        listeUtilisateurs.ItemsSource = users;
    }

    private async Task CheckLogAsync(string email, string password)
    {
        var users = await _userService.ObtenirUtilisateursAsync();
        Debug.WriteLine($"Number of users retrieved: {users.Count}");

        foreach (var user in users)
        {
            if (email == user.email && password == user.password)
            {
                isLoggedIn = true;
                await DisplayAlert("Succès", "Connexion réussie!", "OK");
                await ChargerUtilisateurs();
                return;
            }
        }

        await DisplayAlert("Erreur", "Email ou mot de passe incorrect.", "OK");
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;

        await CheckLogAsync(email, password);
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage(_userService));
    }
}
