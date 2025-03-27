using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MauiApp2.page
{
    public partial class RegistrationPage : ContentPage
    {
        private ObservableCollection<Course> RegisteredCourses = new();
        private ObservableCollection<Course> SearchResults = new();

        public RegistrationPage(string email)
        {
            InitializeComponent();
            LoadRegisteredCourses(email);
        }

        private void LoadRegisteredCourses(string email)
        {
            // Mock registered courses
            RegisteredCourses.Add(new Course { CourseName = "Mathematics 101" });
            RegisteredCourses.Add(new Course { CourseName = "Computer Science 102" });

            RegisteredCoursesView.ItemsSource = RegisteredCourses;
        }

        private void OnSearchClicked(object sender, EventArgs e)
        {
            string query = CourseSearchEntry.Text?.ToLower();
            
            var allCourses = new[]
            {
                new Course { CourseName = "Mathematics 101" },
                new Course { CourseName = "Physics 201" },
                new Course { CourseName = "Computer Science 102" }
            };

            SearchResults.Clear();
            foreach (var course in allCourses.Where(c => c.CourseName.ToLower().Contains(query)))
            {
                SearchResults.Add(course);
            }

            SearchResultsView.ItemsSource = SearchResults;
        }

        private void OnRegisterClicked(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.BindingContext is Course course)
            {
                RegisteredCourses.Add(course);
                RegisteredCoursesView.ItemsSource = null;
                RegisteredCoursesView.ItemsSource = RegisteredCourses;
            }
        }

        private void OnDropCourseClicked(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.BindingContext is Course course)
            {
                RegisteredCourses.Remove(course);
                RegisteredCoursesView.ItemsSource = null;
                RegisteredCoursesView.ItemsSource = RegisteredCourses;
            }
        }
    }

    public class Course
    {
        public string CourseName { get; set; }
    }
}
