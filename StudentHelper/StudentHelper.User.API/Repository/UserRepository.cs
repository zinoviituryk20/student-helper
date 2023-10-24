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
        public UserDto CreateUpdateUser(UserDto userDto)
        {
            var user = _mapper.Map<TblUser>(userDto);

            if(user.UserId.Equals(0))
                _dbContext.Add(user);
            else
                _dbContext.Update(user);

            _dbContext.SaveChanges();

            return _mapper.Map<UserDto>(user);
        }

        public bool DeleteUser(int userId)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.UserId == userId);

            if(user == null)
                return false;

            _dbContext.Users.Remove(user);

            return true;
        }

        public UserDto GetUser(int userid)
        {
            var user = _dbContext.Users.FirstOrDefault(u=>u.UserId == userid);
            return _mapper.Map<UserDto>(user);
        }

        public IEnumerable<UserDto> GetUsers()
        {
            var users = _dbContext.Users.ToList();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}
