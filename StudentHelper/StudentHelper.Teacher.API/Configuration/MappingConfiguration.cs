using AutoMapper;
using DbStudentHelper.Data;
using StudentHelper.Teacher.API.Models;

namespace StudentHelper.Teacher.API.Configuration
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMapping()
        {
            var config = new MapperConfiguration(config =>
            {
                //user model map
                config.CreateMap<UserDto, TblUser>().ReverseMap();

                //school model map
                config.CreateMap<ClassDto, TblClass>().ReverseMap();
                config.CreateMap<SubjectDto, TblSubject>().ReverseMap();

            });

            return config;
        }
    }
}
