using System;
using System.Collections.Generic;
using AspnetCoreEFCoreExample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspnetCoreEFCoreExample
{
    public class DataBaseContext : DbContext
    {
        public DbSet<MyModel> MyModels { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        { 

        }

       
    } 

}
