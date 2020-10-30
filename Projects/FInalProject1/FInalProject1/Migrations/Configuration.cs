namespace FInalProject1.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FInalProject1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<FInalProject1.DAL.FinalProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.FinalProjectContext context)
        {
            var developers = new List<Developer>
            {
                new Developer {Email = "george.gd6@gmail.com", Password = "111111",
                    ContactInfo = new ContactInfo{FirstName = "George", LastName = "Dermentzis", City = "Drama", DateOfBirth = DateTime.Parse("1995-11-6")},
                    Education = new Education {School = "Aristotle University of Thessaloniki (AUTH)", Degree = "Bachelor of Science", Field = "Mathematics", StartYear = 2013, EndYear = 2019}},
                new Developer {Email = "vlachou.af@gmail.com", Password = "222222",
                    ContactInfo = new ContactInfo{FirstName = "Afroditi", LastName = "Vlachou", City = "Athens", DateOfBirth = DateTime.Parse("1995-8-18")},
                    Education = new Education {School = "Aristotle University of Thessaloniki (AUTH)", Degree = "BS", Field = "Mathematics", StartYear = 2013, EndYear = 2019}},
                new Developer {Email = "ioannhsgrigoriou@gmail.com", Password = "333333",
                    ContactInfo = new ContactInfo{FirstName = "Giannis", LastName = "Grigoriou", City = "Athens", DateOfBirth = DateTime.Parse("1995-5-8")},
                    Education = new Education {School = "Aristotle University of Thessaloniki (AUTH)", Degree = "Bachelor's Degree", Field = "Mathematics", StartYear = 2013, EndYear = 2019}}
            };
            developers.ForEach(d => context.Developers.AddOrUpdate(x => x.Email, d));
            context.SaveChanges();

            //var skills = new List<Skill>
            //{
            //    new Skill {Name = ""}, new Skill {Name = ""}, new Skill {Name = ""}, new Skill {Name = ""}, new Skill {Name = ""},
            //    new Skill {Name = ""}, new Skill {Name = ""}, new Skill {Name = ""}, new Skill {Name = ""}, new Skill {Name = ""}
            //};
            //skills.ForEach(s => context.Skills.AddOrUpdate(x => x.ID, s));
            //context.SaveChanges();
        }
    }
}
