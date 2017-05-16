using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.VarnishLog;
using Infrastructure.Interfaces;
using System.IO;
using Infrastructure.Utils;

namespace Infrastructure.Repositories
{
    public class FileRepository : IRepository<VarnishLog>
    {
        private readonly IEnumerable<VarnishLog> _logs;
        private readonly IParser<VarnishLog> _varnishLogParser;
        public FileRepository(IParser<VarnishLog> varnishLogParser)
        {
            _varnishLogParser = varnishLogParser;

            var dict = Directory.GetCurrentDirectory();
            var file = dict + @"/varnish.log";

            _logs = File.ReadAllLines(file).Select(line => _varnishLogParser.Parse(line));
        }

        public Task<VarnishLog> Get(Expression<Func<VarnishLog, bool>> predicate)
        {
            return (new TaskFactory()).StartNew(() => _logs.AsQueryable().FirstOrDefault(predicate));
        }

        public IQueryable<VarnishLog> GetAll()
        {
            return _logs.AsQueryable();
        }

        public IQueryable<VarnishLog> Find(Expression<Func<VarnishLog, bool>> predicate)
        {
            return _logs.AsQueryable().Where(predicate);
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