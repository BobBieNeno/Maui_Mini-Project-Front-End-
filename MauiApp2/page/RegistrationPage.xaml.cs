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
                    CourseName = "Computer Science 102", 
                    CourseCode = "CS102",
                    Credits = "4",
                    Instructor = "Prof. Johnson"
                }, new CourseDisplay 
    { 
        CourseName = "Chemistry 103", 
        CourseCode = "CHEM103", 
        Credits = "3", 
        Instructor = "Dr. Taylor"
    },
    new CourseDisplay 
    { 
        CourseName = "English 104", 
        CourseCode = "ENG104", 
        Credits = "2", 
        Instructor = "Ms. Green"
    },
    new CourseDisplay 
    { 
        CourseName = "Biology 105", 
        CourseCode = "BIO105", 
        Credits = "3", 
        Instructor = "Dr. Brown"
    } ,
    new CourseDisplay 
                { 
                    CourseName = "Physics 201", 
                    CourseCode = "PHYS201",
                    Credits = "4",
                    Instructor = "Dr. Williams"
                },
            };

            SearchResults.Clear();
            foreach (var course in allCourses.Where(c => 
                c.CourseName.ToLower().Contains(query) || 
                c.CourseCode.ToLower().Contains(query)))
            {
                SearchResults.Add(course);
            }
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.CommandParameter is CourseDisplay course)
{
    // Check if the course is already registered
    if (!RegisteredCourses.Any(c => c.CourseCode == course.CourseCode))
    {
        // Ask for confirmation before adding the course
        var confirm = await DisplayAlert("ยืนยันการลงทะเบียนรายวิชา", 
                                         $"คุณต้องการลงทะเบียนรายวิชา {course.CourseCode} - {course.CourseName} ใช่หรือไม่?", 
                                         "ใช่", "ไม่");

        if (confirm)
        {
            RegisteredCourses.Add(course);  // Add the course to the registered list
            SearchResults.Remove(course);   // Remove the course from the search results
        }
    }
    else
    {
        // Show an alert if the course is already registered
        await DisplayAlert("Registration", "You are already registered for this course.", "OK");
    }
}

        }

       private async void OnDropCourseClicked(object sender, EventArgs e)
{
    if (sender is Button btn && btn.CommandParameter is CourseDisplay course)
    {
        bool result = await DisplayAlert("ยืนยันการถอนรายวิชา", 
                                     $"คุณต้องการถอนรายวิชา {course.CourseCode} - {course.CourseName} ใช่หรือไม่?", 
                                     "ยืนยัน", 
                                     "ยกเลิก");

    if (result)
    {
        RegisteredCourses.Remove(course);
        
        // ถ้าต้องการเพิ่มกลับเข้า SearchResults
        // if (SearchResults.Any(c => c.CourseCode == course.CourseCode))
        // {
        //     SearchResults.Add(course);
        // }
    }
    }
}


        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void OnFilterClicked(object sender, EventArgs e)
        {
            // Implement filter functionality
            DisplayAlert("Filters", "Filter functionality coming soon!", "OK", "Close");
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