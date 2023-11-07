using AutoMapper;
using DbStudentHelper;
using Microsoft.EntityFrameworkCore;
using StudentHelper.Teacher.API.Models;

namespace StudentHelper.Teacher.API.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentHelperDbContext _dbContext;
        private readonly IMapper _mapper;
        public StudentRepository(StudentHelperDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<UserDto> GetClassStudents(int classId)
        {
            var students = _dbContext.Classes.Include(c => c.Students)
                .Where(c => c.ClassId == classId)
                .Select(c => c.Students)
                .ToList();

            return _mapper.Map<IEnumerable<UserDto>>(students);
        }
    }
}
