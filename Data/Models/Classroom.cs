using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DiplomaWork.Data.Models
{
    [Index(nameof(Name),IsUnique = true)]
    public class Classroom
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string? Name { get; set; }
        public Lesson? Lesson { get; set; }

    }
}
