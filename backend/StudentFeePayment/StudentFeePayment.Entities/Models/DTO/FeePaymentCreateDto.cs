using Microsoft.EntityFrameworkCore;
using StudentFeePayment.Entities.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentFeePayment.Entities.Models.DTO
{
    public class FeePaymentCreateDto
    {
        [Required(ErrorMessage = "Fee amount is required.")]
        [Precision(16, 2)]
        public decimal FeeAmount { get; set; }

        [ConcurrencyCheck]
        [Required]
        public bool IsPaid { get; set; }

        [Required(ErrorMessage = "Date of payment is required.")]
        [DataType(DataType.Date)]
        public DateTime PaidDate { get; set; }

        [Required(ErrorMessage = "Fee year is required.")]
        public int FeeYear { get; set; }

        [StringLength(200)]
        public string Remarks { get; set; }

        [Required(ErrorMessage = "Student selection is required.")]
        public String StudentId { get; set; }
    }
}
