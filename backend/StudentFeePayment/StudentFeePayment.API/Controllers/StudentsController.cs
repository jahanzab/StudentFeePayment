using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentFeePayment.Entities.Models.Domain;
using StudentFeePayment.Entities.Models.DTO;
using StudentPayment.Contracts;

namespace StudentFeePayment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public StudentsController(IRepositoryWrapper repository, IMapper mapper)
        {
            this._mapper = mapper;
            _repository = repository;
        }


        [EnableCors("DefaultPolicy")]
        [HttpGet]
        public async Task<IActionResult> GetAlStudents()
        {
            var studentsResult = _mapper.Map<IEnumerable<StudentDto>>(await _repository.Student.GetAllStudentsAsync());
            return Ok(studentsResult);
        }

        [EnableCors("DefaultPolicy")]
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var response = _mapper.Map<StudentDetailsDto>(await _repository.Student.GetStudentByIdAsync(id));

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [EnableCors("DefaultPolicy")]
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> EditStudent([FromRoute] int id, CreateUpdateStudentDto req)
        {
            var student = _mapper.Map<Student>(req);
            student.Id = id;

            Student updatedStudent;

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            try
            {
                updatedStudent = _repository.Student.UpdateStudentById(student);
                await _repository.SaveAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }

            var response = _mapper.Map<StudentDetailsDto>(updatedStudent);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [EnableCors("DefaultPolicy")]
        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateUpdateStudentDto req)
        {
            var student = _mapper.Map<Student>(req);

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            try
            {
               _repository.Student.CreateStudent(student);
                await _repository.SaveAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

            var response = _mapper.Map<StudentDetailsDto>(student);

            if (response == null)
                return NotFound();

            return Ok(response);
        }
    }
}
