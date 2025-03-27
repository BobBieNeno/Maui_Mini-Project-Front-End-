using Microsoft.Maui.Controls;
using System;

namespace MauiApp2.page
{
    public partial class ProfilePage : ContentPage
    {
        private string userEmail;
        private string userStudentId;

        public ProfilePage(string email)
        {
            InitializeComponent();
            userEmail = email;
            LoadProfile(email);
        }

        private void LoadProfile(string email)
        {
            // Mock data (ควรดึงจาก Database)
            userStudentId = "65011212243";
            
            // Update UI elements
            NameLabel.Text = "เอกชัย ไสยันต์";
            StudentIDLabel.Text = $"Student ID: {userStudentId}";
            EmailLabel.Text = email;
            PhoneLabel.Text = "+66 XX-XXX-XXXX";
            CurrentCreditsLabel.Text = "15/22";
            RemainingCreditsLabel.Text = "7";
        }

        private async void OnViewRegistrationClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage(userEmail));
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void OnNotificationClicked(object sender, EventArgs e)
        {
            // Implement notification logic
        }

        private void OnSettingsClicked(object sender, EventArgs e)
        {
            // Implement settings navigation
        }

        private async void OnScheduleClicked(object sender, EventArgs e)
        {
            // Navigate to schedule page
            // await Navigation.PushAsync(new SchedulePage());
        }

        private async void OnHomeClicked(object sender, EventArgs e)
        {
            // Navigate to home page
            // await Navigation.PushAsync(new HomePage());
        }
    }
}