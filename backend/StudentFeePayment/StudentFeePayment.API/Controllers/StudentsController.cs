using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentFeePayment.Entities.Models.DTO;
using StudentPayment.Contracts;

namespace StudentFeePayment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            this._studentRepository = studentRepository;
            this._mapper = mapper;
        }


        [EnableCors("DefaultPolicy")]
        [HttpGet]
        public async Task<IActionResult> GetAlStudents()
        {
            return Ok(await _studentRepository.GetAllAsync<StudentDTO>());
        }

        [EnableCors("DefaultPolicy")]
        [HttpGet]
        [Route("{id:Int}")]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var response = await _studentRepository.GetByIdAsync<StudentDTO>(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }
    }
}
