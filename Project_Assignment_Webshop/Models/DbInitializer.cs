using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Project_Assignment_Webshop.Models
{
    public class DbInitializer
    {
        internal static void Initialize(
            HandleWebshopsDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager
            )
        {
            // Check if our database is created if not then create it
            context.Database.EnsureCreated();

            //Look for any Databasedata
            if (context.Roles.Any() &&
                context.Products.Any() &&
                context.OrderRows.Any()
                //context.Assignments.Any() &&
                //context.Teachers.Any()
                )
            {
                return; //DB has been seeded
            }

            //----------Roles seed-----------------------------------//

            IdentityRole[] identityRoles = new IdentityRole[]
            {
                new IdentityRole("Admin"),
                new IdentityRole("God")

            };
            foreach (var role in identityRoles)
            {
                roleManager.CreateAsync(role).Wait();
            }

            //--------------Users seed-------------------------------//

            IdentityUser[] identityUsers = new IdentityUser[]
            {
                new IdentityUser("Admin"),
                new IdentityUser("God")
            };

            identityUsers[0].Email = "a@a.a";
            identityUsers[1].Email = "g@g.g";

            string[] passwords = { "Qwerty!123456", "Password!123456" };

            for (int i = 0; i < identityUsers.Length; i++)
            {
                userManager.CreateAsync(identityUsers[i], passwords[i]);
            }

            //----------Role to Users seed----------------------------//




            //-------Students seeed-----------------------------------//

            //var studentSeed = new Student[]
            //{
            //    new Student(){
            //        F_Name = "Kent",
            //        L_Name = "Olsson",
            //        E_mail = "kent.olsson@gmail.com"
            //    },
            //    new Student(){
            //        F_Name = "Max",
            //        L_Name = "Olsson",
            //        E_mail = "max.olsson@gmail.com"
            //    },
            //    new Student(){
            //        F_Name = "Tindra",
            //        L_Name = "Snövit",
            //        E_mail = "tindra.snövit@gmail.com"
            //    }
            //};

            //foreach (Student student in studentSeed)
            //{
            //    context.Students.Add(student);
            //}
            //context.SaveChanges();

            ////-------Courses seeed-----------------------------------//

            //var courseSeed = new Course[]
            //{
            //    new Course(){
            //        Title = "Identity",
            //        Description = "Asp-Mvc-Identity with Content Management System"
            //    },
            //    new Course(){
            //        Title = "Database",
            //        Description = "Asp-Mvc-Database with EntityFramework"
            //    },
            //    new Course(){
            //        Title = "Models",
            //        Description = "Asp-Mvc-Models with ViewModels"
            //    }
            //};

            //foreach (Course course in courseSeed)
            //{
            //    context.Courses.Add(course);
            //}
            //context.SaveChanges();

            ////-------Assignments seeed-----------------------------------//

            //var assignmentSeed = new Assignment[]
            //{
            //    new Assignment(){
            //        Title = "Lecture",
            //        Description = "Lecture Asp.net Mvc Identity with Content Management System"
            //    },
            //    new Assignment(){
            //        Title = "Assignment",
            //        Description = "Assignment Asp.net Mvc-Database with EntityFramework"
            //    },
            //    new Assignment(){
            //        Title = "Workshop",
            //        Description = "Workshop Asp.net Mvc-Models with ViewModels"
            //    }
            //};

            //foreach (Assignment assignment in assignmentSeed)
            //{
            //    context.Assignments.Add(assignment);
            //}
            //context.SaveChanges();

            ////-------Teachers seeed-----------------------------------//

            //var teacherSeed = new Teacher[]
            //{
            //    new Teacher(){
            //        Title = "Senior Teacher",
            //        F_Name = "Ulf",
            //        L_Name = "Bengtsson",
            //        E_mail = "ulf@gmail.com"
            //    },
            //    new Teacher(){
            //        Title = "Youtube Teacher",
            //        F_Name = "Mosh",
            //        L_Name = "Magandi",
            //        E_mail = "mosh@gmail.com"
            //    },
            //    new Teacher(){
            //        Title ="Teacher assistent",
            //        F_Name = "Mikael",
            //        L_Name = "Aurell",
            //        E_mail = "aurell.mikael@gmail.com"
            //    }
            //};

            //foreach (Teacher teacher in teacherSeed)
            //{
            //    context.Teachers.Add(teacher);
            //}
            //context.SaveChanges();
        }
    }
}
