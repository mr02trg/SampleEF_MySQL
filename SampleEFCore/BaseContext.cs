using Microsoft.EntityFrameworkCore;
using SampleEFCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleEFCore
{
    public class BaseContext : DbContext
    {

        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }

        public DbSet<MyValue> MyValues { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Seed
            builder.Entity<MyValue>().HasData(
                new MyValue
                {
                    Id = 1,
                    Name = "Value1"
                },
                new MyValue
                {
                    Id = 2,
                    Name = "Value2"
                }
            );
            #endregion
        }
    }
}
