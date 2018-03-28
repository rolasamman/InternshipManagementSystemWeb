using InternshipManagementSystemWeb.Models;
using InternshipManagementSystemWeb.ViewModels;

namespace InternshipManagementSystemWeb.App_Start
{
    /// <summary>
    /// Configuration of AutoMapper class
    /// Add all the required mappings between model and view models here
    /// </summary>
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeViewModel>().ReverseMap();
                cfg.CreateMap<Student, StudentViewModel>().ReverseMap();
                cfg.CreateMap<Firm, FirmViewModel>().ReverseMap();
                cfg.CreateMap<Supervisor, SupervisorViewModel>().ReverseMap();
                cfg.CreateMap<InternshipCourse, InternshipCourseViewModel>().ReverseMap();

            });
        }
    }
}