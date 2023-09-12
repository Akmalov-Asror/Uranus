using Microsoft.EntityFrameworkCore;
using Urnaus.Shared;

namespace Urnaus.Server.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> User { get; set; }
    public DbSet<Teacher> Teacher { get; set; }
    public DbSet<Contact> Contact { get; set; }
    public DbSet<Test> Test { get; set; }
    public DbSet<Course> Course { get; set; }
    public DbSet<Education> Education { get; set; }
    public DbSet<Feedback> Feedback { get; set; }
    public DbSet<Result> Result { get; set; }
    public DbSet<Lesson> Lesson { get; set; }
    public DbSet<Urnaus.Shared.Task> Task { get; set; }
    public DbSet<Homework> Homework { get; set; }
    public DbSet<TaskAnswer> TaskAnswers { get; set; }

}