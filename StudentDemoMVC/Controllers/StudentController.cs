using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student.Business.Services.Services.Abstract;
using Student.Business.Services.Utilities;
using Student.Entity.Services.Models.Dto;
using StudentDemoMVC.Helper;
using StudentDemoMVC.Models;
using System.Text.Json;
using MB = System.Reflection.MethodBase;

namespace StudentDemoMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IStudentService studentService, ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        [HttpGet]
        [Route("StudentAll")]
        public async Task<IActionResult> GetAll(PaginationFilter paginationFilter)
        {
            try
            {
                var paginatedStudentDtosResult = PagingFunction.GetPage(await _studentService.GetStudents(), paginationFilter.PageSize, paginationFilter.PageNumber);

                return Ok(paginatedStudentDtosResult);
            }
            catch (Exception exception)
            {
                _logger.LogError($"An error occurred during the request - {exception}. Service info: {MB.GetCurrentMethod()?.Name} ");

                return BadRequest("Something went wrong");
            }
        }

        [HttpGet]
        [Route("Student")]
        public async Task<IActionResult> GetStudent(int id)
        {
            try
            {
                var resultJsonInfo = JsonSerializer.Serialize(await _studentService.GetStudent(id));

                _logger.LogInformation($"{MB.GetCurrentMethod()?.Name} - Relevant registration information - Id : {id} Json Info : {resultJsonInfo}");

                return Ok(await _studentService.GetStudent(id));
            }
            catch (Exception exception)
            {
                _logger.LogError($"An error occurred during the request - {exception}. Service info: {MB.GetCurrentMethod()?.Name} ");

                return BadRequest("Something went wrong");
            }
        }


        [HttpPut]
        [Route("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent(StudentDto studentDto)
        {
            try
            {
                var resultJsonInfo = JsonSerializer.Serialize(studentDto);

                _logger.LogInformation($"Updated registration information - Json Info : {resultJsonInfo}");

                return Ok(await _studentService.UpdateStudent(studentDto));
            }
            catch (StudentNotFoundException)
            {
                return NotFound($"Student not found.!");
            }
            catch (Exception exception)
            {
                _logger.LogError($"An error occurred during the request - {exception}. Service info: {MB.GetCurrentMethod()?.ReflectedType?.FullName} ");

                return BadRequest("Something went wrong");
            }
        }

        [HttpPost]
        [Route("CreateStudent")]
        public async Task<IActionResult> AddStudent(StudentDto studentDto)
        {
            try
            {
                var resultJsonInfo = JsonSerializer.Serialize(studentDto);

                _logger.LogInformation($"Added registration information - Json Info : {resultJsonInfo}");

                return Ok(await _studentService.AddStudent(studentDto));
            }
            catch (Exception exception)
            {
                _logger.LogError($"An error occurred during the request - {exception}. Service info: {MB.GetCurrentMethod()?.ReflectedType?.FullName} ");

                return BadRequest("Something went wrong");
            }
        }

        [HttpDelete]
        [Route("DeleteStudent")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var resultJsonInfo = JsonSerializer.Serialize(await _studentService.GetStudent(id));

                _logger.LogInformation($"{MB.GetCurrentMethod()?.Name} - Deleted registration information - Id : {id} Json Info : {resultJsonInfo}");

                await _studentService.DeleteStudent(id);

                return Ok();
            }
            catch (StudentNotFoundException)
            {
                return NotFound($"No record found to be deleted.!");
            }
            catch (Exception exception)
            {
                _logger.LogError($"An error occurred during the request - {exception}. Service info: {MB.GetCurrentMethod()?.Name} ");

                return BadRequest("Something went wrong");
            }
        }

    }
}
