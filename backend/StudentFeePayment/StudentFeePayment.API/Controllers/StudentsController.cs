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

        /// <summary>
        /// Get List of all existing Students
        /// </summary>
        /// <returns></returns>
        [EnableCors("DefaultPolicy")]
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var studentsResult = _mapper.Map<IEnumerable<StudentDto>>(await _repository.Student.GetAllStudentsAsync());
            return Ok(studentsResult);
        }

        /// <summary>
        /// Get a single Student on basis of id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Edit a single Student entity on basis of id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        [EnableCors("DefaultPolicy")]
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> EditStudent([FromRoute] int id, CreateUpdateStudentDto req)
        {
            if (_repository.Student.IsupdateOrCreate(req.StudentNumber))
            {
                ModelState.AddModelError("StudentNumber", "Student Number must be unique for every student.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var student = _mapper.Map<Student>(req);
            student.Id = id;

            Student updatedStudent;

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

        /// <summary>
        /// Create new Student entity
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [EnableCors("DefaultPolicy")]
        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateUpdateStudentDto req)
        {
            if(_repository.Student.IsupdateOrCreate(req.StudentNumber))
            {
                ModelState.AddModelError("StudentNumber", "Student Number must be unique for every student.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var student = _mapper.Map<Student>(req);

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

        /// <summary>
        /// Delete existing Student entity on basis of id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [EnableCors("DefaultPolicy")]
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteStudentById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            try
            {
                _repository.Student.DeleteStudent(id);
                await _repository.SaveAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

            return Ok();
        }
    }
}
