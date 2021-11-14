using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        public IGroupRepository GroupRepository { get; }
        Task SaveAsync();
    }
}
