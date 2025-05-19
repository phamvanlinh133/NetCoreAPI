using Microsoft.EntityFrameworkCore;
using DemoMVC.Models;
using DemoMVC.Models.Entities;
namespace DemoMVC.Data
{
    using Microsoft.EntityFrameworkCore;
    using DemoMVC.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //Ánh xạ class Student vào trong csdl => tạo ra bảng Students
        

        public DbSet<Person> Person { get; set; } = default!;

        public DbSet<Employee> Employee { get; set; } = default!;

         public DbSet<MemberUnit> MemberUnit  { get; set; } = default!;
    }
}