using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSqlInject
{
    internal class DataTestDevContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=148.148.148.97;database=datatestdev;trusted_connection=true;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        public List<Test> sp148Test(string a)
        {
            var tests = this.Tests
                .FromSql($"EXECUTE sp148Test {a}")
                .ToList();
            return tests;
        }
    }

    [Table("test")]
    [Keyless]
    public class Test
    {
        public string a { get; set; }
    }
}
