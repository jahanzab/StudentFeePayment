using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentFeePayment.Entities.Models.DTO
{
    public class CreateUpdateStudentDto
    {
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First Name must be a string with a minimum length of 2 and a maximum length of 50.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last Name must be a string with a minimum length of 2 and a maximum length of 50.")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Please provide valid e-mail address.")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Please provide valid phone number.")]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Student Number must be a string with a minimum length of 5 and a maximum length of 20.")]
        public string StudentNumber { get; set; }

        [Required(ErrorMessage = "Student Grade is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Grade must be a string with a minimum length of 2 and a maximum length of 50.")]
        public string Grade { get; set; }
    }
}
