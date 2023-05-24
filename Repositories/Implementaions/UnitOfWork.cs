using Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Data.Entities;
using System.Data.Entity;

namespace Repositories.Implementaions
{
    public class UnitOfWork : IDisposable
    {
        private TaskDbContext context = new TaskDbContext();
        private GenericRepository<Companies> companiesRepository;
        private GenericRepository<Workers> workersRepository;
        private GenericRepository<Tasks> tasksRepository;
        public GenericRepository<Companies> CompaniesRepository
        {
            get
            {

                if (this.companiesRepository == null)
                {
                    this.companiesRepository = new GenericRepository<Companies>(context);
                }
                return companiesRepository;
            }
        }

        public GenericRepository<Workers> WorkersRepository
        {
            get
            {

                if (this.workersRepository == null)
                {
                    this.workersRepository = new GenericRepository<Workers>(context);
                }
                return workersRepository;
            }
        }
        public GenericRepository<Tasks> TasksRepository
        {
            get
            {

                if (this.tasksRepository == null)
                {
                    this.tasksRepository = new GenericRepository<Tasks>(context);
                }
                return tasksRepository;
            }
        }
        public void Edit<T>(T entity) where T : class
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
