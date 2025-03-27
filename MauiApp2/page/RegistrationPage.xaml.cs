using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MauiApp2.page
{
    public partial class RegistrationPage : ContentPage
    {
        public ObservableCollection<CourseDisplay> RegisteredCourses { get; set; }
        public ObservableCollection<CourseDisplay> SearchResults { get; set; }

        public RegistrationPage(string email)
        {
            InitializeComponent();
            InitializeCollections();
            LoadRegisteredCourses(email);
            BindingContext = this;
        }

        private void InitializeCollections()
        {
            RegisteredCourses = new ObservableCollection<CourseDisplay>();
            SearchResults = new ObservableCollection<CourseDisplay>();
        }

        private void LoadRegisteredCourses(string email)
        {
            // Mock registered courses with more details
            RegisteredCourses.Add(new CourseDisplay 
            { 
                CourseName = "Mathematics 101", 
                CourseCode = "MATH101",
                Credits = "3",
                Instructor = "Dr. Smith"
            });
            RegisteredCourses.Add(new CourseDisplay 
            { 
                CourseName = "Computer Science 102", 
                CourseCode = "CS102",
                Credits = "4",
                Instructor = "Prof. Johnson"
            });
        }

        private void OnSearchClicked(object sender, EventArgs e)
        {
            string query = CourseSearchEntry.Text?.ToLower();
            
            var allCourses = new[]
            {
                new CourseDisplay 
                { 
                    CourseName = "Mathematics 101", 
                    CourseCode = "MATH101",
                    Credits = "3",
                    Instructor = "Dr. Smith"
                },
                new CourseDisplay 
                { 
                    CourseName = "Physics 201", 
                    CourseCode = "PHYS201",
                    Credits = "4",
                    Instructor = "Dr. Williams"
                },
                new CourseDisplay 
                { 
                    CourseName = "Computer Science 102", 
                    CourseCode = "CS102",
                    Credits = "4",
                    Instructor = "Prof. Johnson"
                }
            };

            SearchResults.Clear();
            foreach (var course in allCourses.Where(c => 
                c.CourseName.ToLower().Contains(query) || 
                c.CourseCode.ToLower().Contains(query)))
            {
                SearchResults.Add(course);
            }
        }

        private void OnRegisterClicked(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.CommandParameter is CourseDisplay course)
            {
                // Check for duplicate registration
                if (!RegisteredCourses.Any(c => c.CourseCode == course.CourseCode))
                {
                    RegisteredCourses.Add(course);
                    SearchResults.Remove(course);
                }
                else
                {
                    // Optional: Show an alert that the course is already registered
                    DisplayAlert("Registration", "You are already registered for this course.", "OK");
                }
            }
        }

       private void OnDropCourseClicked(object sender, EventArgs e)
{
    if (sender is Button btn && btn.CommandParameter is CourseDisplay course)
    {
        RegisteredCourses.Remove(course);

        // ตรวจสอบว่าคอร์สที่ถูกลบเคยอยู่ในผลลัพธ์การค้นหาหรือไม่
        // if (SearchResults.Any(c => c.CourseCode == course.CourseCode))
        // {
            SearchResults.Add(course);
        // }
    }
}


        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void OnFilterClicked(object sender, EventArgs e)
        {
            // Implement filter functionality
            DisplayAlert("Filters", "Filter functionality coming soon!", "OK");
        }

        private void OnInfoClicked(object sender, EventArgs e)
        {
            // Show registration information
            DisplayAlert("Registration Info", 
                "- Maximum 6 courses per semester\n" +
                "- Minimum 12 credits required\n" +
                "- Add/Drop period ends soon", "Close");
        }
    }

    public class CourseDisplay
    {
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string Credits { get; set; }
        public string Instructor { get; set; }
    }
}