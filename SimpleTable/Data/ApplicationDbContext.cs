using Microsoft.EntityFrameworkCore;
using SimpleTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTable.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public ApplicationDbContext(DbContextOptions options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Production" },
                new Department { Id = 2, Name = "Research and Development" },
                new Department { Id = 3, Name = "Purchasing" },
                new Department { Id = 4, Name = "Marketing" },
                new Department { Id = 5, Name = "Human Resource Management" },
                new Department { Id = 6, Name = "Accounting" });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FirstName = "Cleveland",
                    LastName = "Vicarey",
                    Email = "cvicarey0@rambler.ru",
                    Gender = Gender.Male,
                    Phone = "51 523 699 9284",
                    BirthDate = DateTime.ParseExact("08/29/1997", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    IsCertified = false,
                    DepartmentId = 6
                }, new Employee
                {
                    Id = 2,
                    FirstName = "Francyne",
                    LastName = "Persich",
                    Email = "fpersich1@hibu.com",
                    Gender = Gender.Female,
                    Phone = "62 196 534 2823",
                    BirthDate = DateTime.ParseExact("05/12/1998", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    IsCertified = false,
                    DepartmentId = 2
                }, new Employee
                {
                    Id = 3,
                    FirstName = "Hugo",
                    LastName = "Carlin",
                    Email = "hcarlin2@google.ca",
                    Gender = Gender.Male,
                    Phone = "86 410 472 9880",
                    BirthDate = DateTime.ParseExact("01/29/1977", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    IsCertified = true,
                    DepartmentId = 5
                }, new Employee
                {
                    Id = 4,
                    FirstName = "Clayson",
                    LastName = "Whalley",
                    Email = "cwhalley3@yellowbook.com",
                    Gender = Gender.Male,
                    Phone = "1 149 158 3062",
                    BirthDate = DateTime.ParseExact("03/19/1991", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    IsCertified = false,
                    DepartmentId = 3
                }, new Employee
                {
                    Id = 5,
                    FirstName = "Fairleigh",
                    LastName = "Clemitt",
                    Email = "fclemitt4@wordpress.com",
                    Gender = Gender.Male,
                    Phone = "44 276 410 3141",
                    BirthDate = DateTime.ParseExact("12/06/1993", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    IsCertified = false,
                    DepartmentId = 6
                }, new Employee
                {
                    Id = 6,
                    FirstName = "Erastus",
                    LastName = "Regler",
                    Email = "eregler5@seesaa.net",
                    Gender = Gender.Male,
                    Phone = "962 309 299 2461",
                    BirthDate = DateTime.ParseExact("12/28/1999", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    IsCertified = true,
                    DepartmentId = 6
                }, new Employee
                {
                    Id = 7,
                    FirstName = "Devlin",
                    LastName = "Lankford",
                    Email = "dlankford6@ehow.com",
                    Gender = Gender.Male,
                    Phone = "34 794 445 7780",
                    BirthDate = DateTime.ParseExact("01/10/1990", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    IsCertified = false,
                    DepartmentId = 2
                }, new Employee
                {
                    Id = 8,
                    FirstName = "Halie",
                    LastName = "Benedyktowicz",
                    Email = "hbenedyktowicz7@barnesandnoble.com",
                    Gender = Gender.Female,
                    Phone = "1 304 498 6560",
                    BirthDate = DateTime.ParseExact("01/24/1970", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    IsCertified = true,
                    DepartmentId = 2
                }, new Employee
                {
                    Id = 9,
                    FirstName = "Ransell",
                    LastName = "Wrassell",
                    Email = "rwrassell8@samsung.com",
                    Gender = Gender.Male,
                    Phone = "591 244 781 3894",
                    BirthDate = DateTime.ParseExact("01/25/1994", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    IsCertified = false,
                    DepartmentId = 6
                }, new Employee
                {
                    Id = 10,
                    FirstName = "Kaylil",
                    LastName = "Kubacek",
                    Email = "kkubacek9@ed.gov",
                    Gender = Gender.Female,
                    Phone = "86 209 214 4933",
                    BirthDate = DateTime.ParseExact("01/02/1980", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    IsCertified = false,
                    DepartmentId = 1
                }
                );
        }
    }
}
