using Student.Entity.Services.Models.Helper;

namespace Student.Entity.Services.Models.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public Gender Gender { get; set; }
        public short Active { get; set; }
    }
}
