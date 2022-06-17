using Microsoft.EntityFrameworkCore;
using NewsWeb.Core.Entities;
using System;

namespace NewsWeb.Infraustraucture.EF
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=NewsWeb;Data Source=.");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<News> News { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<AdminAuthentication> Authentications { get; set; }
        public DbSet<UserAuthentication> UserAuthentications { get; set; }
        public DbSet<Ads> Ads { get; set; }
    }
}
