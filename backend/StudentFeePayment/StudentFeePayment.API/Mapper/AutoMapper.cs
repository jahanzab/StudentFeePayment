﻿using AutoMapper;
using StudentFeePayment.Entities.Models.Domain;
using StudentFeePayment.Entities.Models.DTO;

namespace StudentFeePayment.API.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<StudentDTO, Student>();
            CreateMap<Student, StudentDTO>();
        }
    }
}