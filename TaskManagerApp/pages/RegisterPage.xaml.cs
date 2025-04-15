using System;

namespace TaskManagerApp
{
    public partial class RegisterPage : ContentPage
    {
        private readonly UserService _userService;

        public RegisterPage(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            string nom = NomEntry.Text;
            string prenom = PrenomEntry.Text;
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;
            string confirmPassword = ConfirmPasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(prenom) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Erreur", "Tous les champs sont obligatoires.", "OK");
                return;
            }

            if (password != confirmPassword)
            {
                await DisplayAlert("Erreur", "Les mots de passe ne correspondent pas.", "OK");
                return;
            }

            // Add logic to save the user to the database
            await _userService.AjouterUtilisateurAsync(new User
            {
                nom = nom,
                prenom = prenom,
                email = email,
                password = password
            });

            await DisplayAlert("Succès", "Compte créé avec succès.", "OK");

            // Navigate back to the login page
            await Navigation.PopAsync();
        }
    }
}