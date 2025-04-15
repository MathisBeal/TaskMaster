using System.Diagnostics;

namespace TaskManagerApp
{
    public partial class LoginPage : ContentPage
    {
        private readonly UserService _userService;
        private readonly TaskService _taskService;
        private readonly CommentService _commentService;
        private readonly SubTaskService _subTaskService;

        private bool isLoggedIn = false;

        public LoginPage(UserService userService, TaskService taskService, CommentService commentService, SubTaskService subTaskService)
        {
            InitializeComponent();
            _userService = userService;
            _taskService = taskService;
            _commentService = commentService;
            _subTaskService = subTaskService;
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

        private async Task<int> CheckLogAsync(string email, string password)
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
                    return user.idUsers;
                }
            }

            await DisplayAlert("Erreur", "Email ou mot de passe incorrect.", "OK");
            return -1; // Indicate failure
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            int user_id = await CheckLogAsync(email, password);
            if (user_id != -1)
            {
                await Navigation.PushAsync(new TaskManagerApp.HomePage(_userService, _taskService, _commentService, _subTaskService, user_id));
            }
            else
            {
                Debug.WriteLine("Login failed.");
            }
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TaskManagerApp.RegisterPage(_userService));
        }
    }
}
