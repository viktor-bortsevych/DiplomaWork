using Microsoft.EntityFrameworkCore;

namespace DiplomaWork.Data.Models
{
    [Index(nameof(DayOfWeek), nameof(Number), nameof(GroupID), IsUnique=true)]    
    public class Lesson
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public DayOfWeek DayOfWeek { get; set; }
        public int Number { get; set; }

        public string? SubjectID { get; set; }
        public string? TeacherID { get; set; }
        public string? ClassroomID { get; set; }
        public string? GroupID { get; set; }

        public Group? Group { get; set; }
        public Teacher? Teacher { get; set; }
        public Classroom? Classroom { get; set; }
        public Subject? Subject { get; set; }
    }
}
