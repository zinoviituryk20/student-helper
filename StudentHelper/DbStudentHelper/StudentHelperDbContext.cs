using DbStudentHelper.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbStudentHelper
{
    public class StudentHelperDbContext : DbContext
    {
        public StudentHelperDbContext()
        {

        }

        public StudentHelperDbContext(DbContextOptions<StudentHelperDbContext> options)
            : base(options)
        {

        }
        #region db models
        
        // users models
        public virtual DbSet<TblUser> Users { get; set; }

        public virtual DbSet<TblRole> Roles { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=StudentHelper;Trusted_Connection=True;");

            }
        }
    }
}
