using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMA_Wall.DataLayer
{
    internal class DataContext : DbContext
    {
        public DbSet<BO.Message> Messages { get; set; }
        public DbSet<BO.User> Users { get; set; }

        public DataContext() : base("NMA_Wall")
        {

        }
    }
}
