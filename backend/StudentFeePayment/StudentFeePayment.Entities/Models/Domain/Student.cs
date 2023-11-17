using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentFeePayment.Entities.Models.Domain
{
    [Table("Student", Schema = "school")]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is required.")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [ConcurrencyCheck]
        [Required(ErrorMessage = "LastName is required.")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Phone]
        [Required(ErrorMessage = "Phone number is required.")]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }


    }
}
