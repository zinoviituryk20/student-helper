using AutoMapper;
using DbStudentHelper.Data;
using StudentHelper.User.API.Models;

namespace StudentHelper.User.API.Configuration
{
    public class MapingConfiguration
    {
        public static MapperConfiguration RegisterMapping()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<UserDto, TblUser>().ReverseMap();
                config.CreateMap<RoleDto,TblRole>().ReverseMap();
            });

            return config;
        }
    }
}
