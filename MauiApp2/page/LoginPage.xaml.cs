using Microsoft.Maui.Controls;

namespace MauiApp2.page
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            if (username == "a" && password == "a") // Example credentials
            {
                await Navigation.PushAsync(new ProfilePage(username)); // Navigate to HomePage
            }
            else
            {
                ErrorMessage.Text = "Invalid username or password.";
                ErrorMessage.IsVisible = true;
            }
        }
    }
}
