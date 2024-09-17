using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions  dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Survey> surveys { get; set; }
        public DbSet<Classes> classes { get; set;}
        public DbSet<Question> questions { get; set;}
        public DbSet<QuestionType> questionTypes { get; set;}
        public DbSet<Response> responses { get; set;}
    }
}