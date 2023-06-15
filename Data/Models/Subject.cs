using System.ComponentModel.DataAnnotations;

namespace DiplomaWork.Data.Models
{
    public class Subject
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string? Name { get; set; }
        public Lesson? Lesson { get; set; }
    }
}
