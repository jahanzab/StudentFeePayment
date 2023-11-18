using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentFeePayment.Entities.Models.DTO
{
    public class StudentDetailsDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime DOB { get; set; }

        public DateTime CreatedDate { get; set; }

        public string StudentNumber { get; set; }

        public string Grade { get; set; }
    }
}
