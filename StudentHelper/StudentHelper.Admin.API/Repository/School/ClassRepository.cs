using AutoMapper;
using DbStudentHelper;
using DbStudentHelper.Data;
using StudentHelper.Admin.API.Models;

namespace StudentHelper.Admin.API.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly StudentHelperDbContext _dbContext;
        private readonly IMapper _mapper;

        public ClassRepository(StudentHelperDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public bool AssignClassToSchool(int classId, int schoolId)
        {
            var entityExist = ClassExist(classId) && SchoolExist(schoolId);

            if(!entityExist)
                return false;

            var _class = FindClassById(classId);

            _class.EducationInstitutionId = schoolId;

            _dbContext.SaveChanges();

            return true;
        }

        public bool AssignStudentsToClass(int[] studentIds, int classId)
        {
            var entityExist = ClassExist(classId) && UsersExist(studentIds);

            if(!entityExist)
                return false;

            var classStudents = new List<ZtblClassStudent>();

            foreach (var student in studentIds)
            {
                classStudents.Add(new ZtblClassStudent
                {
                    ClassId = classId,
                    StudentId = student
                });
            }

            _dbContext.AddRange(classStudents);
            _dbContext.SaveChanges(true);

            return true;
        }

        public ClassDto CreateUpdateClass(ClassDto classDto)
        {
            var _class = _mapper.Map<TblClass>(classDto);

            if(_class.ClassId.Equals(0))
                _dbContext.Add(classDto);
            else
                _dbContext.Update(classDto);

            _dbContext.SaveChanges();

            return _mapper.Map<ClassDto>(classDto);
        }

        public ClassDto GetClass(int classId)
        {
            var _class = FindClassById(classId);

            return _mapper.Map<ClassDto>(_class);
        }

        public IEnumerable<ClassDto> GetClasses()
        {
            var classes = FindAllClasses().ToList();

            return _mapper.Map<IEnumerable<ClassDto>>(classes);
        }

        public bool RemoveClass(int classId)
        {
            var _class = FindClassById(classId);

            if( _class == null )
                return false;

            _class.Active = false;
            _dbContext.Update( _class );
            _dbContext.SaveChanges();

            return true;
        }

        private IQueryable<TblClass> FindAllClasses()
        {
            return _dbContext.Classes.AsQueryable();
        }

        private TblClass FindClassById(int classId)
        {
            return FindAllClasses().FirstOrDefault(c => c.ClassId == classId);
        }

        private bool ClassExist(int classId)
        {
            return FindClassById(classId) != null;
        }

        private bool UsersExist(int[] userIds)
        {
            var dbIds = _dbContext.Users
                .Where(u=>userIds.Contains(u.UserId))
                .Select(u=>u.UserId);

            var invalidIds = userIds.Except(dbIds);

            return !invalidIds.Any();
        }

        private bool SchoolExist(int schooolId)
        {
            return _dbContext.EducationInstitutions.FirstOrDefault(ed=>ed.EducationInstitutionId == schooolId) != null;
        }
    }
}
