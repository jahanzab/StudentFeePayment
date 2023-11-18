using AutoMapper;
using StudentFeePayment.Entities.Models.Domain;
using StudentFeePayment.Entities.Models.DTO;

namespace StudentFeePayment.API.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<StudentDto, Student>();
            CreateMap<Student, StudentDto>();

            CreateMap<StudentDetailsDto, Student>();
            CreateMap<Student, StudentDetailsDto>();

            CreateMap<CreateUpdateStudentDto, Student>();
            CreateMap<Student, CreateUpdateStudentDto>();
        }
    }
}
