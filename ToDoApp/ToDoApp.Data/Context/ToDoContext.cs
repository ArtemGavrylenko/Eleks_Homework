using Microsoft.EntityFrameworkCore;
using ToDoApp.Data.Models;

namespace ToDoApp.Data.Context;

public class ToDoContext : DbContext
{
    public DbSet<Board> Boards { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Models.Task> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
    //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ToDoAppDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        base.OnConfiguring(optionsBuilder);

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Board>()
            .HasKey(b => b.Id);
        modelBuilder.Entity<Board>()
            .Property(b => b.CreatedAt)
            .IsRequired();

        modelBuilder.Entity<Status>()
            .HasKey(s => s.Id);
        
        modelBuilder.Entity<ToDoApp.Data.Models.Task>()
            .HasKey(t => t.Id);
        modelBuilder.Entity<ToDoApp.Data.Models.Task>()
            .Property(t => t.CreatedAt)
            .IsRequired();
        modelBuilder.Entity<ToDoApp.Data.Models.Task>()
            .HasOne(t => t.Board)
            .WithMany(b => b.Tasks)
            .HasForeignKey(t => t.BoardId);
        modelBuilder.Entity<ToDoApp.Data.Models.Task>()
            .HasOne(t => t.Status)
            .WithMany(s => s.Tasks)
            .HasForeignKey(t => t.StatusId);
        modelBuilder.Entity<ToDoApp.Data.Models.Task>()
            .HasOne(t => t.Assignee)
            .WithMany(u => u.Tasks)
            .HasForeignKey(t => t.AssigneeId);

        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);
    }
}
