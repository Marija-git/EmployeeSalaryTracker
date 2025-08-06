using AutoMapper;
using EmployeeSalaryTracker.API.Dtos;
using EmployeeSalaryTracker.Data.Entities;

namespace EmployeeSalaryTracker.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SalaryHistory,SalaryHistoryDtoResponse>();
            CreateMap<Employee, EmployeeDtoResponse>()
                .ForMember(dest => dest.SalaryHistory, opt => opt.MapFrom(src => src.SalaryHistory));
        }
    }
}
