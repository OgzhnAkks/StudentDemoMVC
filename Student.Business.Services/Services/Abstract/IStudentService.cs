using Student.Entity.Services.Models.Dto;

namespace Student.Business.Services.Services.Abstract
{
    public interface IStudentService
    {
        Task<StudentDto> AddStudent(StudentDto student);
        Task DeleteStudent(int id);
        Task<StudentDto> GetStudent(int id);
        Task<List<StudentDto>> GetStudents();
        Task<StudentDto> UpdateStudent(StudentDto studentDto);
    }
}