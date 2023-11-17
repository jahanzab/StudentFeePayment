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
    }
}
