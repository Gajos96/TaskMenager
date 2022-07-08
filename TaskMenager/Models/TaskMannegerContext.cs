using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskMenager.Models;

namespace TaskMenager.Models
{
    public class TaskMannegerContext : DbContext
    {
        public TaskMannegerContext(DbContextOptions options) : base(options)
        {


        }
        public DbSet<TaskModel> Tasks { get; set; }
    }
}
