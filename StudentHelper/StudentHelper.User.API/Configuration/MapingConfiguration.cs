using AutoMapper;
using DbStudentHelper.Data;
using StudentHelper.Admin.API.Models;

namespace StudentHelper.User.API.Configuration
{
    public class MapingConfiguration
    {
        public static MapperConfiguration RegisterMapping()
        {
            var config = new MapperConfiguration(config =>
            {
                //user model map
                config.CreateMap<UserDto, TblUser>().ReverseMap();
                config.CreateMap<RoleDto, TblRole>().ReverseMap();

                //school model map
                config.CreateMap<EducationInstitutionDto, TblEducationInstitution>().ReverseMap();
                config.CreateMap<ClassDto, TblClass>().ReverseMap();
                config.CreateMap<ClassStudentsDto,ZtblClassStudent>().ReverseMap();


            });

            return config;
        }
    }
}
