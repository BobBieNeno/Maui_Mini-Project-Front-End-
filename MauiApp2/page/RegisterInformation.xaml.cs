using System.Collections.ObjectModel;

namespace MauiApp2.page
{
    public partial class RegisterInformation : ContentPage
    {
        public ObservableCollection<CourseRegistration> Courses { get; set; }

        public RegisterInformation()
        {
            InitializeComponent();
            // Default to the most recent semester
            SemesterPicker.SelectedIndex = 0;
        }
        // private async void OnBackClicked(object sender, EventArgs e)
        // {
          
        // }

        private void OnSemesterPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSemester = SemesterPicker.SelectedItem?.ToString();
            LoadCourseRegistrations(selectedSemester);
        }

        private void LoadCourseRegistrations(string semester)
        {
            // Mock data - in real app, this would come from a database or service
             switch (semester)
  {
      case "1/2566":
          Courses = new ObservableCollection<CourseRegistration>
          {
              new CourseRegistration { CourseCode = "01234567", CourseName = "การเขียนโปรแกรมประยุกต์", Credits = 3, SectionNumber = "001", Grade = "A" },
              new CourseRegistration { CourseCode = "87654321", CourseName = "โครงสร้างข้อมูลและอัลกอริทึม", Credits = 3, SectionNumber = "002", Grade = "B+" },
              new CourseRegistration { CourseCode = "11223344", CourseName = "ระบบปฏิบัติการ", Credits = 3, SectionNumber = "003", Grade = "A-" },
              new CourseRegistration { CourseCode = "55667788", CourseName = "เครือข่ายคอมพิวเตอร์", Credits = 3, SectionNumber = "004", Grade = "B" },
              new CourseRegistration { CourseCode = "99887766", CourseName = "วิศวกรรมซอฟต์แวร์", Credits = 3, SectionNumber = "005", Grade = "B+" },
              new CourseRegistration { CourseCode = "44332211", CourseName = "ปัญญาประดิษฐ์", Credits = 3, SectionNumber = "006", Grade = "A" }
          };
          break;
      case "2/2566":
          Courses = new ObservableCollection<CourseRegistration>
          {
              new CourseRegistration { CourseCode = "56781234", CourseName = "ระบบฐานข้อมูล", Credits = 3, SectionNumber = "001", Grade = "B" },
              new CourseRegistration { CourseCode = "33445566", CourseName = "การประมวลผลภาพ", Credits = 3, SectionNumber = "002", Grade = "A" },
              new CourseRegistration { CourseCode = "22334455", CourseName = "การออกแบบและวิเคราะห์อัลกอริทึม", Credits = 3, SectionNumber = "003", Grade = "B+" },
              new CourseRegistration { CourseCode = "66778899", CourseName = "การขุดค้นข้อมูล", Credits = 3, SectionNumber = "004", Grade = "A-" },
              new CourseRegistration { CourseCode = "11224433", CourseName = "การเรียนรู้ของเครื่อง", Credits = 3, SectionNumber = "005", Grade = "B" },
              new CourseRegistration { CourseCode = "88997766", CourseName = "ความมั่นคงปลอดภัยไซเบอร์", Credits = 3, SectionNumber = "006", Grade = "A" }
          };
          break;
      case "3/2566":
          Courses = new ObservableCollection<CourseRegistration>
          {
              new CourseRegistration { CourseCode = "55664477", CourseName = "เทคโนโลยีเว็บ", Credits = 3, SectionNumber = "001", Grade = "A" },
              new CourseRegistration { CourseCode = "77889900", CourseName = "การพัฒนาแอปพลิเคชันมือถือ", Credits = 3, SectionNumber = "002", Grade = "B+" },
              new CourseRegistration { CourseCode = "99001122", CourseName = "คลาวด์คอมพิวติ้ง", Credits = 3, SectionNumber = "003", Grade = "A-" },
              new CourseRegistration { CourseCode = "22330044", CourseName = "การวิเคราะห์ข้อมูล", Credits = 3, SectionNumber = "004", Grade = "B" },
              new CourseRegistration { CourseCode = "44556677", CourseName = "กราฟิกคอมพิวเตอร์", Credits = 3, SectionNumber = "005", Grade = "A" },
              new CourseRegistration { CourseCode = "66779988", CourseName = "การพัฒนาซอฟต์แวร์อไจล์", Credits = 3, SectionNumber = "006", Grade = "B+" }
          };
          break;
      case "1/2565":
      case "2/2565":
      case "3/2565":
          Courses = new ObservableCollection<CourseRegistration>
          {
              new CourseRegistration { CourseCode = "12345678", CourseName = "หลักการเขียนโปรแกรม", Credits = 3, SectionNumber = "001", Grade = "A" },
              new CourseRegistration { CourseCode = "23456789", CourseName = "ระบบดิจิทัล", Credits = 3, SectionNumber = "002", Grade = "B" },
              new CourseRegistration { CourseCode = "34567890", CourseName = "วิทยาการคอมพิวเตอร์พื้นฐาน", Credits = 3, SectionNumber = "003", Grade = "B+" },
              new CourseRegistration { CourseCode = "45678901", CourseName = "การออกแบบระบบซอฟต์แวร์", Credits = 3, SectionNumber = "004", Grade = "A-" },
              new CourseRegistration { CourseCode = "56789012", CourseName = "การทดสอบซอฟต์แวร์", Credits = 3, SectionNumber = "005", Grade = "B+" },
              new CourseRegistration { CourseCode = "67890123", CourseName = "การพัฒนาเว็บแอปพลิเคชัน", Credits = 3, SectionNumber = "006", Grade = "A" }
          };
          break;
      default:
          Courses = new ObservableCollection<CourseRegistration>();
          break;
  }


            CourseRegistrationCollectionView.ItemsSource = Courses;
            
            // Update total credits
            int totalCredits = Courses.Sum(c => c.Credits);
            TotalCreditsLabel.Text = $"รวมหน่วยกิต: {totalCredits}";
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
        }

        private async Task ImageButton_ClickedAsync(object sender, EventArgs e)
        {
             await Navigation.PopAsync();
        }
    }
    

    public class CourseRegistration
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public string SectionNumber { get; set; }
        public string Grade { get; set; }
    }
}