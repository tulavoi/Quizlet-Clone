using QuizletClone.DTOs.Course;

namespace QuizletClone.ViewModels.Home
{
    public class HomeViewModel
    {
        public List<RecentCourseDTO>? RecentCoursesDTO { get; set; }
        public List<PopularCourseDTO>? PopularCoursesDTO { get; set; }
    }
}
