using AutoMapper;
using DbStudentHelper;
using DbStudentHelper.Data;
using StudentHelper.User.API.Models;

namespace StudentHelper.User.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly StudentHelperDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserRepository(StudentHelperDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public UserDto GetUserById(int userId)
        {
            var user = _dbContext.Users.FirstOrDefault(u=>u.UserId == userId);

            return _mapper.Map<UserDto>(user);
        }

        public UserDto UpdateUserInfo(UserDto userDto)
        {
            var user = _mapper.Map<TblUser>(userDto);

            _dbContext.Update(user);

            _dbContext.SaveChanges();

            return _mapper.Map<UserDto>(user);
        }
    }
}
