using Student.Entity.Services.Models.Helper;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Entity.Services.Models.Entity
{
    [Table("Students", Schema = "student")]
    public class Student
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public Gender Gender { get; set; }
        public short Active { get; set; }
    }
}