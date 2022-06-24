using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<ExpertPosition> ExpertPositions  { get; set; }
    }
}
