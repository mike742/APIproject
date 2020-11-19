using APIproject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIproject.Data
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"server=localhost;user=root;password=;database=aspdb;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
