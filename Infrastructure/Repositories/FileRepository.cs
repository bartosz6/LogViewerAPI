using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.VarnishLog;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class FileRepository : IRepository<VarnishLog>
    {
        public FileRepository()
        {
        }

        public Task<VarnishLog> Get(Expression<Func<VarnishLog, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<VarnishLog> GetAll()
        {
            var list = new List<VarnishLog>()
            {
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
                new VarnishLog() { Url = "test url" },
            };

            return list.AsQueryable();
        }

        public IQueryable<VarnishLog> Find(Expression<Func<VarnishLog, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task Create(VarnishLog entity)
        {
            throw new NotImplementedException();
        }

        public Task CreateMany(IEnumerable<VarnishLog> entities)
        {
            throw new NotImplementedException();
        }

        public Task Delete(VarnishLog entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(VarnishLog entity)
        {
            throw new NotImplementedException();
        }
    }
}