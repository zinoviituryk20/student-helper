using AutoMapper;
using DbStudentHelper.Data;
using StudentHelper.User.API.Models;

namespace StudentHelper.User.API.Configuration
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMapping()
        {
            var config = new MapperConfiguration(config =>
            {
                //user model map
                config.CreateMap<UserDto, TblUser>().ReverseMap();

            });

            return config;
        }
    }
}
