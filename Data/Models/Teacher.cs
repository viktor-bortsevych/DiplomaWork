using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DiplomaWork.Data.Models
{
    [Index(nameof(FirstName), nameof(LastName), IsUnique = true)]
    public class Teacher
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }

        public Group? Group { get; set; }
        public Lesson? Lesson { get; set; }
    }
}
