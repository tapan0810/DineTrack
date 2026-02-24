using DineTrack.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DineTrack.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Hostel> Hostels { get; set; }
        public DbSet<Mess> Messes { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Complaints> Complaints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ==============================
            // UNIQUE CONSTRAINTS
            // ==============================

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Menu>()
                .HasIndex(m => new { m.MessId, m.MenuDate, m.MealType })
                .IsUnique();

            modelBuilder.Entity<Review>()
                .HasIndex(r => new { r.StudentId, r.MenuItemId })
                .IsUnique();


            // ==============================
            // RELATIONSHIPS
            // ==============================

            // User → Role (Many-to-One)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);


            // User → Hostel (Many-to-One)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Hostel)
                .WithMany(h => h.Users)
                .HasForeignKey(u => u.HostelId)
                .OnDelete(DeleteBehavior.Restrict);


            // Mess → Hostel
            modelBuilder.Entity<Mess>()
                .HasOne(m => m.Hostel)
                .WithMany(h => h.Messes)
                .HasForeignKey(m => m.HostelId)
                .OnDelete(DeleteBehavior.Restrict);


            // Mess → ManagedByUser
            modelBuilder.Entity<Mess>()
                .HasOne(m => m.ManagedByUser)
                .WithMany()
                .HasForeignKey(m => m.ManagedByUserId)
                .OnDelete(DeleteBehavior.Restrict);


            // Menu → Mess
            modelBuilder.Entity<Menu>()
                .HasOne(m => m.Mess)
                .WithMany(ms => ms.Menus)
                .HasForeignKey(m => m.MessId)
                .OnDelete(DeleteBehavior.Cascade);


            // Menu → CreatedByUser
            modelBuilder.Entity<Menu>()
                .HasOne(m => m.CreatedByUser)
                .WithMany()
                .HasForeignKey(m => m.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);


            // MenuItem → Menu
            modelBuilder.Entity<MenuItem>()
                .HasOne(mi => mi.Menu)
                .WithMany(m => m.MenuItems)
                .HasForeignKey(mi => mi.MenuId)
                .OnDelete(DeleteBehavior.Cascade);


            // Review → MenuItem
            modelBuilder.Entity<Review>()
                .HasOne(r => r.MenuItem)
                .WithMany(mi => mi.Reviews)
                .HasForeignKey(r => r.MenuItemId)
                .OnDelete(DeleteBehavior.Cascade);


            // Review → Student (User)
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Student)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.StudentId)
                .OnDelete(DeleteBehavior.Restrict);


            // Complaint → Mess
            modelBuilder.Entity<Complaints>()
                .HasOne(c => c.Mess)
                .WithMany(m => m.Complaints)
                .HasForeignKey(c => c.MessId)
                .OnDelete(DeleteBehavior.Restrict);


            // Complaint → Student
            modelBuilder.Entity<Complaints>()
                .HasOne(c => c.Student)
                .WithMany(u => u.Complaints)
                .HasForeignKey(c => c.StudentId)
                .OnDelete(DeleteBehavior.Restrict);


            // Complaint → ResolvedByUser
            modelBuilder.Entity<Complaints>()
                .HasOne(c => c.ResolvedByUser)
                .WithMany()
                .HasForeignKey(c => c.ResolvedBy)
                .OnDelete(DeleteBehavior.Restrict);


            // ==============================
            // SEED ROLES
            // ==============================

            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "Student" },
                new Role { RoleId = 3, RoleName = "MessAuthority" }
            );
        }
    }
}
