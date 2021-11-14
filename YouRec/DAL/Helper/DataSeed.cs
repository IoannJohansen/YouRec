using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helper
{
    public static class DataSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Group>().HasData(new Group { Id=1, GroupName = "Games"}, new Group { Id = 2, GroupName = "Movies" }, new Group { Id = 3, GroupName = "Smoking" }, new Group { Id = 1, GroupName = "Papaya" });
        }
    }
}
