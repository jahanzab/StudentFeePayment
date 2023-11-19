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
    public class FeePaymenUpdateDto
    {
        [StringLength(200)]
        public string Remarks { get; set; }
    }
}
