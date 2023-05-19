using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Context
{
    public class TaskDbContext : DbContext
    {
        public DbSet<Workers> Workers { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Companies> Companies { get; set; }
        public DbSet<TaskToWorkers> TaskToWorkers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>();
            modelBuilder.Entity<Companies>(); 
            modelBuilder.Entity<TaskToWorkers>();
            modelBuilder.Entity<Workers>()
                .HasRequired(w => w.Tasks)
                .WithMany()
                .HasForeignKey(w => w.TaskId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }

}
