using Microsoft.Maui.Controls;
using System;

namespace MauiApp2.page
{
    public partial class ProfilePage : ContentPage
    {
        private string userEmail;

        public ProfilePage(string email)
        {
            InitializeComponent();
            userEmail = email;
            LoadProfile(email);
        }

        private void LoadProfile(string email)
        {
            // Mock data (ควรดึงจาก Database)
            NameLabel.Text = "John Doe";
            EmailLabel.Text = email;
        }

        private async void OnViewRegistrationClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage(userEmail));
        }
    }
}
