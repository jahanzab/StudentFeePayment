using AutoMapper;
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
    public class FeePaymentsController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public FeePaymentsController(IRepositoryWrapper repository, IMapper mapper)
        {
            this._mapper = mapper;
            _repository = repository;
        }

        /// <summary>
        /// Get List of all paid student fee records
        /// </summary>
        /// <returns></returns>
        [EnableCors("DefaultPolicy")]
        [HttpGet]
        public async Task<IActionResult> GetAllFeePayment()
        {
            var studentsResult = _mapper.Map<IEnumerable<FeePaymentDto>>(await _repository.FeePayment.GetAllFeePaymentsAsync());
            return Ok(studentsResult);
        }

        /// <summary>
        /// Get a single Fee payment records on basis of id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [EnableCors("DefaultPolicy")]
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetFeePaymentById([FromRoute] int id)
        {
            var response = _mapper.Map<FeePaymentDetailsDto>(await _repository.FeePayment.GetFeePaymentByIdAsync(id));

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        /// <summary>
        /// Update remarks for already payments.
        /// System doesn't allow to change the completed transaction fields but remarks for now 
        /// </summary>
        /// <param name="id"></param>
        [EnableCors("DefaultPolicy")]
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> EditFeePayment([FromRoute] int id, FeePaymenUpdateDto req)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            try
            {
                _repository.FeePayment.UpdateFeePaymentById(id, req.Remarks);
                await _repository.SaveAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

            return Ok();
        }

        /// <summary>
        /// Record new Fee Payment transaction
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [EnableCors("DefaultPolicy")]
        [HttpPost]
        public async Task<IActionResult> CreateStudent(FeePaymentCreateDto req)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var feePayment = _mapper.Map<FeePayment>(req);

            try
            {
                _repository.FeePayment.CreateFeePayment(feePayment);
                await _repository.SaveAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

            var response = _mapper.Map<FeePaymentDetailsDto>(feePayment);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

    }
}
