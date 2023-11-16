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

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [ConcurrencyCheck]
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Phone]
        [MaxLength(20)]
        [Required]
        public string Phone { get; set; }

        [MaxLength(200)]
        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }


    }
}
