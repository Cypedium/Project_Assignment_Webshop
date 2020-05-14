using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Project_Assignment_Webshop.Models
{
    public class DbInitializer
    {
        private static readonly int menu_number = 0;
        private static readonly int accessories_number = 0;
        private static readonly int drinks_number = 0;
        private static readonly int productType_number = 0;
        internal static void Initialize(
            HandleWebshopsDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager
            )
        {
            // Check if our database is created if not then create it
            context.Database.EnsureCreated();

            //Look for Data in the Db
            if (
                context.Products.Any()
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


           //--Write role to users seed here---


            //-------Products seeed-----------------------------------//
          
            Product[] productSeed = new Product[]
            {               
                /*--Pizza Klass 1----------------------------------------*/
                new Product()
                {
                    ProductType = productType_number+1,
                    Number =  menu_number+1,
                    Name = "Vesuvo",
                    Description = "Skinka",
                    Price = 70
                },

                new Product()
                {
                    ProductType = productType_number,
                    Number =  menu_number+1,
                    Name = "Calzone",
                    Description = "Skinka (Inbakad)",
                    Price = 70
                },

                new Product()
                {
                    ProductType = productType_number,
                    Number =  menu_number+1,
                    Name = "Salami",
                    Description = "Salami, Färsk Vitlök",
                    Price = 70
                },
               
                /*--Pizza Klass 2------------*/
                new Product()
                {
                    ProductType = productType_number+1,
                    Number =  menu_number+1,
                    Name = "Roma",
                    Description = "Champinjoner, Räkor",
                    Price = 75
                },

                new Product()
                {
                    ProductType = productType_number,
                    Number =  menu_number+1,
                    Name = "Vegetarisk",
                    Description = "Champinjoner, Lök, Paprika, Ananas, Oliver, Kronärtskocka",
                    Price = 75
                },

                new Product()
                {
                    ProductType = productType_number,
                    Number =  menu_number+1,
                    Name = "Kreta",
                    Description = "Pepperonikorv, Salladsost, Färsk Tomat, Vitlök, Mozzarella",
                    Price = 75
                },

                /*--Pizza Klass 3-----------------------------*/
                new Product()
                {
                    ProductType = productType_number+1,
                    Number =  menu_number+1,
                    Name = "Kebabpizza",
                    Description = "Kebab, Lök, Tomat, Pefferoni, Vitlöksås",
                    Price = 80
                },

                new Product()
                {
                    ProductType = productType_number,
                    Number =  menu_number+1,
                    Name = "Gyrospizza",
                    Description = "Gyros, Lök, Tomat, Pefferoni, Vitlöksås",
                    Price = 80
                },

                new Product()
                {
                    ProductType = productType_number,
                    Number =  menu_number+1,
                    Name = "Qautro Stagioni",
                    Description = "Skinka, Räkor, Musslor, Championer, Kronärtskocka",
                    Price = 80
                },

                /*-----Pizza Special-----------*/
                new Product()
                {
                    ProductType = productType_number+1,
                    Number = menu_number+1,
                    Name = "Josefins Special",
                    Description = "Kebab, Ananas, Lök, Tomat, Pefferoni, Vitlöksås",
                    Price = 90
                },

                new Product()
                {
                    ProductType = productType_number,
                    Number = menu_number+1,
                    Name = "Mikaels Special",
                    Description = "Salami, Färsk Vitlök, Ägg, Championer, Röd Chili",
                    Price = 90
                },

                new Product()
                {
                    ProductType = productType_number,
                    Number = menu_number+1,
                    Name = "Rinkabyholm",
                    Description = "Kebab/Gyros, Tomater, Salladsost, Mozzarella, Tomat",
                    Price = 90
                },

                    /*--Sallader-----------------*/
                new Product()
                {
                    ProductType = productType_number+1,
                    Number = menu_number+1,
                    Name = "Räksallad",
                    Description = "Räkor, Ost, Sparris, Ananas, Citron",
                    Price = 80
                },

                new Product()
                {
                    ProductType = productType_number,
                    Number = menu_number+1,
                    Name = "Tonfisksallad",
                    Description = "Tonfisk, Paprika, Ost, Ananas, Citron",
                    Price = 80
                },

                new Product()
                {
                    ProductType = productType_number,
                    Number = menu_number+1,
                    Name = "Kebab/Gyros sallad",
                    Description = "Kebab/Gyros, Oliver, Salladsost",
                    Price = 80
                },

                /*--Hamburgare---------------*/
                new Product()
                {
                    ProductType = productType_number+1,
                    Number = menu_number+1,
                    Name = "Happy Burger 45 g",
                    Description = "Ketchup",
                    Price = 40
                },

                new Product()
                {
                    ProductType = productType_number,
                    Number = menu_number+1,
                    Name = "Högrev 200 g",
                    Description = "Högrev Angus, Hickoryrökt Bacon, Amerikansk Dressing, Ketchup, Sallad, Gurka, Tomat",
                    Price = 99
                },

                new Product()
                {
                    ProductType = productType_number,
                    Number = menu_number+1,
                    Name = "SuperBurger 150 g",
                    Description = "Nötkött, Ost, Dressing, Ketchup, Gurka, Tomat",
                    Price = 45
                },

                /*--Korv------------------------*/
                new Product()
                {
                    ProductType = productType_number+1,
                    Number = menu_number+1,
                    Name = "Smal Kokt",
                    Description = "Bröd",
                    Price = 20
                },

                new Product()
                {
                    ProductType = productType_number,
                    Number = menu_number+1,
                    Name = "Smal Grillad",
                    Description = "Strips",
                    Price = 45
                },

                new Product()
                {
                    ProductType = productType_number,
                    Number = menu_number+1,
                    Name = "Smal Grillad Special",
                    Description = "Bröd, Mos",
                    Price = 15
                },

                /*--A La Carte----------------*/
                new Product()
                {
                    ProductType = productType_number+1,
                    Number = menu_number+1,
                    Name = "Köttbullar med mos",
                    Description = "10 st Köttbullar, lingon, mos",
                    Price = 55
                },

                new Product()
                {
                    ProductType = productType_number,
                    Number = menu_number+1,
                    Name = "Lövbit med Strips",
                    Description = "Lövbit, Strips, Perslijesmör, sallad, gurka, tomat",
                    Price = 55
                },

                new Product()
                {
                    ProductType = productType_number,
                    Number = menu_number+1,
                    Name = "Panerad Flundra",
                    Description = "Kalmarflundra, ströbröd, ägg",
                    Price = 79
                },

                /*--Kebab----------------*/
                new Product()
                {
                    ProductType = productType_number+1,
                    Number = menu_number+1,
                    Name = "Kebab med bröd",
                    Description = "Kebab, Pitabröd, Sallad, Röd Lök, Gurka, Tomat, Pefferoni, Sås",
                    Price = 65
                },

                new Product()
                {
                    ProductType = productType_number+1,
                    Number = menu_number+1,
                    Name = "Gyros med bröd",
                    Description = "Gyros, Pitabröd, Sallad, Röd Lök, Gurka, Tomat, Pefferoni, Sås",
                    Price = 65
                },

                new Product()
                {
                    ProductType = productType_number+1,
                    Number = menu_number+1,
                    Name = "Kycklingrulle",
                    Description = "Kyckling, Tunnbröd, Sallad, Röd Lök, Gurka, Tomat, Pefferoni, Sås",
                    Price = 80
                },

                new Product()
                {
                    ProductType = productType_number+1,
                    Number = menu_number+1,
                    Name = "Falafeltallrik",
                    Description = "Falafel, Strips, Sallad, Röd Lök, Gurka, Tomat, Pefferoni, Sås",
                    Price = 80
                },

                /*Tillbehör/Accessories*/
                new Product()
                {
                    ProductType = productType_number+1,
                    Number = accessories_number+1,
                    Name = "Pizzasallad",
                    Description = "Vitkål, olja, kryddor",
                    Price = 5
                },

                new Product()
                {
                    ProductType = productType_number,
                    Number = accessories_number+1,
                    Name = "Rostad Lök",
                    Description = "Gul Lök, kryddor",
                    Price = 5
                },

                new Product()
                {
                    ProductType = productType_number,
                    Number = accessories_number+1,
                    Name = "Ananas",
                    Description = "Ananas",
                    Price = 5
                },

                /*--Såser------------------*/
                new Product()
                {
                    ProductType = productType_number+1,
                    Number = accessories_number+1,
                    Name = "Vitlökssås",
                    Description = "Creme Fraiche, vitlök, olivolja",
                    Price = 5
                },

                new Product()
                {
                    ProductType = productType_number,
                    Number = accessories_number+1,
                    Name = "Röd stark sås",
                    Description = "Tomatsås, Röd Chili, Grön Chili, Olivolja",
                    Price = 5
                },

                new Product()
                {
                    ProductType = productType_number,
                    Number = accessories_number+1,
                    Name = "Road Island",
                    Description = "Road Island",
                    Price = 5
                },

                /*--Drycker---------------*/
                new Product()
                {
                    ProductType = productType_number+1,
                    Number = drinks_number+1,
                    Name = "Coca cola",
                    Description = "33 ml",
                    Price = 15
                },

                new Product()
                {
                    ProductType = productType_number,
                    Number = drinks_number+1,
                    Name = "Mineralvatten",
                    Description = "50 ml",
                    Price = 20
                },

                new Product()
                {
                    ProductType = productType_number,
                    Number = drinks_number+1,
                    Name = "Fanta",
                    Description = "1 l",
                    Price = 40
                }

            };

            foreach (Product product in productSeed)
            {
                context.Products.Add(product);
            }
            context.SaveChanges();
            

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
