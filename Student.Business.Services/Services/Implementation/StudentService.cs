using AutoMapper;
using Student.Business.Services.Services.Abstract;
using Student.Business.Services.Utilities;
using Student.DataAccess.Services.Repositores.Abstract;
using Student.Entity.Services.Models.Dto;
using ST = Student.Entity.Services.Models.Entity;

namespace Student.Business.Services.Repositores.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<List<StudentDto>> GetStudents()
        {
            var students = await _studentRepository.GetList(x => x.Active == 1);

            return _mapper.Map<List<StudentDto>>(students);
        }

        public async Task<StudentDto> GetStudent(int id)
        {
            var student = await _studentRepository.Get(x => x.Id == id && x.Active == 1);

            if (student is null)
            {
                throw new StudentNotFoundException();
            }

            return _mapper.Map<StudentDto>(student);
        }


        public async Task<StudentDto> AddStudent(StudentDto student)
        {
            var studentValue = await _studentRepository.Add(_mapper.Map<ST::Student>(student));

            return _mapper.Map<StudentDto>(studentValue);
        }

        public async Task<StudentDto> UpdateStudent(StudentDto studentDto)
        {
            var student = await _studentRepository.Get(x => x.Id == studentDto.Id && x.Active == 1);

            if (student is null)
            {
                throw new StudentNotFoundException();
            }

            var studentUpdateValue = _mapper.Map<ST::Student>(studentDto);

            return _mapper.Map<StudentDto>(await _studentRepository.Update(studentUpdateValue));
        }

        public async Task DeleteStudent(int id)
        {
            var student = await _studentRepository.Get(x => x.Id == id);

            if (student is null)
            {
                throw new StudentNotFoundException();
            }

            await _studentRepository.Delete(student);
        }


    }
}
