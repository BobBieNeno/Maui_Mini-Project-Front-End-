using System.Collections.ObjectModel;

namespace MauiApp2.page
{
    public partial class RegistrationView : ContentPage
    {
        private Dictionary<string, ObservableCollection<CourseRegistration>> SemesterCourses 
            = new Dictionary<string, ObservableCollection<CourseRegistration>>
        {
            {
                "1/2565", new ObservableCollection<CourseRegistration>
                {
                    new CourseRegistration 
                    { 
                        CourseCode = "01234001", 
                        CourseName = "คณิตศาสตร์พื้นฐาน", 
                        Credits = 3, 
                        SectionNumber = "001",
                        // Grade = "A"
                    },
                    new CourseRegistration 
                    { 
                        CourseCode = "01234002", 
                        CourseName = "ฟิสิกส์พื้นฐาน", 
                        Credits = 3, 
                        SectionNumber = "002",
                        // Grade = "B+"
                    },
                    new CourseRegistration 
                    { 
                        CourseCode = "01234003", 
                        CourseName = "เคมีพื้นฐาน", 
                        Credits = 3, 
                        SectionNumber = "003",
                        // Grade = "B"
                    }
                }
            },
            {
                "2/2565", new ObservableCollection<CourseRegistration>
                {
                    new CourseRegistration 
                    { 
                        CourseCode = "01234004", 
                        CourseName = "การเขียนโปรแกรมคอมพิวเตอร์", 
                        Credits = 3, 
                        SectionNumber = "001",
                        // Grade = "A"
                    },
                    new CourseRegistration 
                    { 
                        CourseCode = "01234005", 
                        CourseName = "โครงสร้างข้อมูล", 
                        Credits = 3, 
                        SectionNumber = "002",
                        // Grade = "B+"
                    }
                }
            },
            {
                "3/2565", new ObservableCollection<CourseRegistration>
                {
                    new CourseRegistration 
                    { 
                        CourseCode = "01234006", 
                        CourseName = "ระบบฐานข้อมูล", 
                        Credits = 3, 
                        SectionNumber = "001",
                        // Grade = "A-"
                    },
                    new CourseRegistration 
                    { 
                        CourseCode = "01234007", 
                        CourseName = "การวิเคราะห์และออกแบบระบบ", 
                        Credits = 3, 
                        SectionNumber = "002",
                        // Grade = "B"
                    }
                }
            },
            {
                "1/2566", new ObservableCollection<CourseRegistration>
                {
                    new CourseRegistration 
                    { 
                        CourseCode = "01234008", 
                        CourseName = "เครือข่ายคอมพิวเตอร์", 
                        Credits = 3, 
                        SectionNumber = "001",
                        // Grade = "B+"
                    },
                    new CourseRegistration 
                    { 
                        CourseCode = "01234009", 
                        CourseName = "ปัญญาประดิษฐ์", 
                        Credits = 3, 
                        SectionNumber = "002",
                        // Grade = "A"
                    }
                }
            },
            {
                "2/2566", new ObservableCollection<CourseRegistration>
                {
                    new CourseRegistration 
                    { 
                        CourseCode = "01234010", 
                        CourseName = "การพัฒนาแอปพลิเคชันมือถือ", 
                        Credits = 3, 
                        SectionNumber = "001",
                        // Grade = "A-"
                    },
                    new CourseRegistration 
                    { 
                        CourseCode = "01234011", 
                        CourseName = "การประมวลผลแบบกลุ่มเมฆ", 
                        Credits = 3, 
                        SectionNumber = "002",
                        // Grade = "B+"
                    }
                }
            },
            {
                "3/2566", new ObservableCollection<CourseRegistration>
                {
                    new CourseRegistration 
                    { 
                        CourseCode = "01234012", 
                        CourseName = "โครงงานทางวิศวกรรมซอฟต์แวร์", 
                        Credits = 3, 
                        SectionNumber = "001",
                        Grade = "A"
                    },
                    new CourseRegistration 
                    { 
                        CourseCode = "01234013", 
                        CourseName = "การตลาดดิจิทัล", 
                        Credits = 3, 
                        SectionNumber = "002",
                        // Grade = "B+"
                    }
                }
            }
        };

        public RegistrationView()
        {
            InitializeComponent();
            // Default to the most recent semester
            SemesterPicker.SelectedIndex = 0;
            LoadCoursesForSemester(SemesterPicker.SelectedItem.ToString());
        }

        private void OnSemesterPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSemester = SemesterPicker.SelectedItem?.ToString();
            LoadCoursesForSemester(selectedSemester);
        }

        private void LoadCoursesForSemester(string semester)
        {
            if (SemesterCourses.TryGetValue(semester, out var courses))
            {
                PastRegistrationsCollectionView.ItemsSource = courses;
                
                // Update total credits
                int totalCredits = courses.Sum(c => c.Credits);
                TotalCreditsLabel.Text = $"รวมหน่วยกิต: {totalCredits}";
            }
            else
            {
                PastRegistrationsCollectionView.ItemsSource = null;
                TotalCreditsLabel.Text = "รวมหน่วยกิต: 0";
            }
        }


        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
               await Navigation.PopAsync();
        }
    }

    public class RegisteredCourses
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public string SectionNumber { get; set; }
        public string Grade { get; set; }
        // public Color GradeColor 
        // {
        //     get
        //     {
        //         return Grade switch
        //         {
        //             "A" => Colors.Green,
        //             "A-" => Colors.DarkGreen,
        //             "B+" => Colors.Blue,
        //             "B" => Colors.DarkBlue,
        //             _ => Colors.Black
        //         };
        //     }
        // }
    }
}