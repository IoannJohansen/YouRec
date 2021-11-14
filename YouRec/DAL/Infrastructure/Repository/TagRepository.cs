using DAL.Data;
using DAL.Infrastructure.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Infrastructure.Repository
{
    internal class TagRepository : IRepository<Tag>
    {
        public TagRepository(ApplicationDbContext applicationDbContext)
        {

        }



        public Task<Tag> CreateAsync(Tag item)
        {
            throw new NotImplementedException();
        }

        public Task<Tag> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tag> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCount()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tag>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Tag> UpdateAsync(Tag item)
        {
            throw new NotImplementedException();
        }
    }
}
