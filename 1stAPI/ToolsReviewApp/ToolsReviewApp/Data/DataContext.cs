using Microsoft.EntityFrameworkCore;
using ToolsReviewApp.Models;

namespace ToolsReviewApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
       
        public DbSet<Companie> Companies { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<ToolOwner> ToolOwners { get; set; }
        public DbSet<ToolCategory> ToolCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToolCategory>()
                .HasKey(tc => new { tc.ToolId, tc.CategoryId });
            modelBuilder.Entity<ToolCategory>()
                .HasOne(t => t.Tool)
                .WithMany(tc => tc.ToolCategories)
                .HasForeignKey(c => c.ToolId);
            modelBuilder.Entity<ToolCategory>()
                .HasOne(t => t.Category)
                .WithMany(tc => tc.ToolCategories)
                .HasForeignKey(c => c.CategoryId);


            //--------------------

            modelBuilder.Entity<ToolOwner>()
                .HasKey(to => new { to.ToolId, to.OwnerId });
            modelBuilder.Entity<ToolOwner>()
                .HasOne(t => t.Tool)
                .WithMany(tc => tc.ToolOwners)
                .HasForeignKey(o => o.ToolId);
            modelBuilder.Entity<ToolOwner>()
                .HasOne(t => t.Owner)
                .WithMany(to => to.ToolOwners)
                .HasForeignKey(o => o.OwnerId);

        }
    }
}
