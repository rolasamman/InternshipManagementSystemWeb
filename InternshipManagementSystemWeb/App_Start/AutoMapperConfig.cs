/*    
 *      Description:    This is an Internship Management System for a university. 
 *                      The project handles internship matters of the internship department of the university. 
 *                      The aim of the project is to make communications between users most efficient and effective. 
 *                      It also provides users with necessary data and records needed information.
 *      
 *      Author:         Rola Samman
*/

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
                cfg.CreateMap<Admin, AdminViewModel>().ReverseMap();
                cfg.CreateMap<Announcement, AnnouncementViewModel>().ReverseMap();
                cfg.CreateMap<Attendance, AttendanceViewModel>().ReverseMap();
                cfg.CreateMap<Complain, ComplainViewModel>().ReverseMap();
                cfg.CreateMap<Employee, EmployeeViewModel>().ReverseMap();
                cfg.CreateMap<Firm, FirmViewModel>().ReverseMap();
                cfg.CreateMap<Instructor, InstructorViewModel>().ReverseMap();
                cfg.CreateMap<InternshipCourse, InternshipCourseViewModel>().ReverseMap();
                cfg.CreateMap<InternshipCriterion, InternshipCriterionViewModel>().ReverseMap();
                cfg.CreateMap<InternshipEvaluation, InternshipEvaluationViewModel>().ReverseMap();
                cfg.CreateMap<MeetingOnCampus, MeetingOnCampusViewModel>().ReverseMap();
                cfg.CreateMap<Section, SectionViewModel>().ReverseMap();
                cfg.CreateMap<Student, StudentViewModel>().ReverseMap();
                cfg.CreateMap<Supervisor, SupervisorViewModel>().ReverseMap();
                cfg.CreateMap<SupervisorCriterion, SupervisorCriterionViewModel>().ReverseMap();
                cfg.CreateMap<SupervisorEvaluation, SupervisorEvaluationViewModel>().ReverseMap();
                cfg.CreateMap<VisitOnSite, VisitOnSiteViewModel>().ReverseMap();

            });
        }
    }
}