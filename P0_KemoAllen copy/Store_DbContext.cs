using Microsoft.EntityFrameworkCore;
using System;


namespace P0_KemoAllen
{
    public class Store_DbContext : DbContext
    {
        //public DbSet<> of objects

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }
        
    }
}