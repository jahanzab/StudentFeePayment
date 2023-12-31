﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentFeePayment.Entities.Models.DTO
{
    public class StudentDto
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }

        public string StudentNumber { get; set; }

        public string Grade { get; set; }
    }
}
