using Student.DataAccess.Services.Repositores.Abstract;
using Student.DataAccess.Services.Contexts;
using ST = Student.Entity.Services.Models.Entity;

namespace Student.DataAccess.Services.Repositores.Implementation
{
    public class StudentRepository : GenericRepository<ST::Student>, IStudentRepository
    {
        private readonly StudentContext _studentContext;

        public StudentRepository(StudentContext studentContext) : base(studentContext)
        {
            _studentContext = studentContext;
        }
    }
}
