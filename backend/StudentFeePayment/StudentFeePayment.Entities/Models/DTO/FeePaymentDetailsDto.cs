using StudentFeePayment.Entities.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentFeePayment.Entities.Models.DTO
{
    public class FeePaymentDetailsDto
    {
        public int Id { get; set; }

        public decimal FeeAmount { get; set; }

        public bool IsPaid { get; set; }

        public DateTime PaidDate { get; set; }

        public int FeeYear { get; set; }

        public Student Student { get; set; } = new();

        public string Remarks { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
