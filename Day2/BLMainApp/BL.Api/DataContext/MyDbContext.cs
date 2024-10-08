﻿using Microsoft.EntityFrameworkCore;

namespace BL.Api.DataContext
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }


    }
}
