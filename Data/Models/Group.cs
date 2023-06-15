using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DiplomaWork.Data.Models
{
    [Index(nameof(Name), IsUnique=true)]
    public class Group
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string? Name { get; set; }
        public string? TeacherID { get; set; }
        public Teacher? Teacher { get; set; }
        public Lesson? Lesson { get; set; }
    }
}
