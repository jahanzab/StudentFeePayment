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

            CreateMap<FeePaymentDto, FeePayment>();
            CreateMap<FeePayment, FeePaymentDto>();

            CreateMap<FeePaymentDetailsDto, FeePayment>();
            CreateMap<FeePayment, FeePaymentDetailsDto>();

            CreateMap<FeePaymentCreateDto, FeePayment>()
                .ForPath(dest => dest.Student.Id, opts => opts.MapFrom(src => src.StudentId));
            //CreateMap<FeePayment, FeePaymentCreateDto>();
        }
    }
}
