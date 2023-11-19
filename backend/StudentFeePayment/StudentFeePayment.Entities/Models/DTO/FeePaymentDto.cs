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
    public class FeePaymentDto
    {
        public int Id { get; set; }

        public decimal FeeAmount { get; set; }

        public bool IsPaid { get; set; }

        public DateTime PaidDate { get; set; }

        public int FeeYear { get; set; }

        public Student Student { get; set; } = new();
    }
}
