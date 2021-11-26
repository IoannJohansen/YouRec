using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Infrastructure.Interfaces
{
    public interface IRatingRepository
    {
        Task<Rating> AddAsync(Rating rating);
        Task<Rating> UpdateAsync(Rating rating);
    }
}
