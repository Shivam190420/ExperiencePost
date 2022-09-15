using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ExperiencePost.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                 new Employee { EmpID = 1, FirstName = "Aaron", LastName = "Hawkins", Password = "arron@123", CellNumber = "(660) 663-4518", Email = "aron.hawkins@aol.com" },
                 new Employee { EmpID = 2, FirstName = "Hedy", LastName = "Greene", Password = "hedy@123", CellNumber = "(608) 265-2215", Email = "hedy.greene@aol.com" },
                 new Employee { EmpID = 3, FirstName = "Melvin", LastName = "Porter", Password = "melvin@123", CellNumber = "(959) 119-8364", Email = "melvin.porter@aol.com" }
             );
            modelBuilder.Entity<Skill>().HasData(
            new Skill { SkillId = 1, EmpID = 1, SkillName = "Microsoft Office Suite", Role = "Business Analyst", ExperienceInYears = 2 },
            new Skill { SkillId = 2, EmpID = 1, SkillName = "Testing", Role = "Developer", ExperienceInYears = 3 },
            new Skill { SkillId = 3, EmpID = 1, SkillName = "Stakeholder Management", Role = "Project Lead", ExperienceInYears = 4 }
           );
        }
    }
}