namespace infolink.rect_asp_hr.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class MySQLContext : DbContext
    {
        public DbSet<Employee> Employee { get; set;}

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {
        }
    }
}