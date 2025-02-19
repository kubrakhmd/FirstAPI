﻿using System.Collections.Generic;
using FirstAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.DAL
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
