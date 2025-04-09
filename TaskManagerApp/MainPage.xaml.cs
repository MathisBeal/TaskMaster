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

        // Vérifie si l'utilisateur est connecté avant de charger la liste des utilisateurs
        if (isLoggedIn)
        {
            var users = await _userService.ObtenirUtilisateursAsync();
            Debug.WriteLine($"Number of users retrieved: {users.Count}");
            foreach (var user in users)
            {
                Debug.WriteLine($"User: {user.nom} {user.prenom}");
            }
            listeUtilisateurs.ItemsSource = users;
        }
        else
        {
            // Affiche un message pour rappeler à l'utilisateur de se connecter
            Debug.WriteLine("Veuillez vous connecter pour voir les utilisateurs.");
        }
    }

    private void OnLoginClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;

        // Exemple simple de validation
        if (email == "admin@example.com" && password == "password123")
        {
            isLoggedIn = true;
            DisplayAlert("Succès", "Connexion réussie!", "OK");
            // Recharge la liste des utilisateurs après la connexion réussie
            OnAppearing();
        }
        else
        {
            DisplayAlert("Erreur", "Email ou mot de passe incorrect.", "OK");
        }
    }
}
