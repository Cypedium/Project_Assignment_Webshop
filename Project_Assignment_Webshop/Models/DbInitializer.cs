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
        internal static void Initialize(
            HandleWebshopsDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager
            )
        {
            // Check if our database is created if not then create it
            context.Database.EnsureCreated();

            //----------Roles seed-----------------------------------//

            if (!roleManager.Roles.Any())
            {
                IdentityRole[] identityRoles = new IdentityRole[]
                {
                    new IdentityRole("Admin"),
                    new IdentityRole("God")
                };

                foreach (var role in identityRoles)
                {
                    roleManager.CreateAsync(role).Wait();
                }
            }

            //--------------Users seed-------------------------------//

            if (!userManager.Users.Any())
            {
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
                    var result = userManager.CreateAsync(identityUsers[i], passwords[i]).Result;
            
                    if (result.Succeeded)
                    {
                        Console.WriteLine("Created user: " + identityUsers[i].Email);
                    }

                    else if (result.Errors.Any())
                    {
                        Console.WriteLine("Failed to create user:");

                        foreach (IdentityError error in result.Errors)
                        {
                            Console.WriteLine($"Code: {error.Code}\nDetails: {error.Description}");
                        }
                    }
                }
            }

            //----------Role to Users seed----------------------------//

            if (!context.UserRoles.Any())
            {
                var result = userManager.AddToRoleAsync(userManager.FindByNameAsync("a@a.a").Result, "Admin").Result;
            
                if (result.Succeeded)
                {
                    Console.WriteLine("role assigned to a@a.a");
                }
                else if (result.Errors.Any())
                {
                    Console.WriteLine("Errror list:");
                    foreach (IdentityError error in result.Errors)
                    {
                        Console.WriteLine($"Code: {error.Code}\nDetails: {error.Description}");
                    }
                }
            }
           
            
            //-------Products seeed-----------------------------------//

            if (!context.Products.Any())
            {
                Product[] productSeed = new Product[]
                {
                    new Product() /*--Pizza Klass 1--*/
                    {
                        ProductType = 1,
                        Number = 1,
                        Name = "Vesuvo",
                        Description = "Skinka",
                        Price = 70
                    },
                    new Product()
                    {
                        ProductType = 1,
                        Number = 2,
                        Name = "Calzone",
                        Description = "Skinka (Inbakad)",
                        Price = 70
                    },
                    new Product()
                    {
                        ProductType = 1,
                        Number = 3,
                        Name = "Salami",
                        Description = "Salami, Färsk Vitlök",
                        Price = 70
                    },                            
                    new Product() /*--Pizza Klass 2------------*/
                    {
                        ProductType = 2,
                        Number = 4,
                        Name = "Roma",
                        Description = "Champinjoner, Räkor",
                        Price = 75
                    },
                    new Product()
                    {
                        ProductType = 2,
                        Number = 5,
                        Name = "Vegetarisk",
                        Description = "Champinjoner, Lök, Paprika, Ananas, Oliver, Kronärtskocka",
                        Price = 75
                    },
                    new Product()
                    {
                        ProductType = 2,
                        Number = 6,
                        Name = "Kreta",
                        Description = "Pepperonikorv, Salladsost, Färsk Tomat, Vitlök, Mozzarella",
                        Price = 75
                    },                
                    new Product() /*--Pizza Klass 3--*/
                    {
                        ProductType = 3,
                        Number = 7,
                        Name = "Kebabpizza",
                        Description = "Kebab, Lök, Tomat, Pefferoni, Vitlöksås",
                        Price = 80
                    },
                    new Product()
                    {
                        ProductType = 3,
                        Number = 8,
                        Name = "Gyrospizza",
                        Description = "Gyros, Lök, Tomat, Pefferoni, Vitlöksås",
                        Price = 80
                    },
                    new Product()
                    {
                        ProductType = 3,
                        Number = 9,
                        Name = "Qautro Stagioni",
                        Description = "Skinka, Räkor, Musslor, Championer, Kronärtskocka",
                        Price = 80
                    },               
                    new Product() /*-----Pizza Special-----------*/
                    {
                        ProductType = 4,
                        Number = 10,
                        Name = "Josefins Special",
                        Description = "Kebab, Ananas, Lök, Tomat, Pefferoni, Vitlöksås",
                        Price = 90
                    },
                    new Product()
                    {
                        ProductType = 4,
                        Number = 11,
                        Name = "Mikaels Special",
                        Description = "Salami, Färsk Vitlök, Ägg, Championer, Röd Chili",
                        Price = 90
                    },
                    new Product()
                    {
                        ProductType = 4,
                        Number = 12,
                        Name = "Rinkabyholm",
                        Description = "Kebab/Gyros, Tomater, Salladsost, Mozzarella, Tomat",
                        Price = 90
                    },                   
                    new Product() /*--Sallader--*/
                    {
                        ProductType = 5,
                        Number = 1,
                        Name = "Räksallad",
                        Description = "Räkor, Ost, Sparris, Ananas, Citron",
                        Price = 80
                    },
                    new Product()
                    {
                        ProductType = 5,
                        Number = 2,
                        Name = "Tonfisksallad",
                        Description = "Tonfisk, Paprika, Ost, Ananas, Citron",
                        Price = 80
                    },
                    new Product()
                    {
                        ProductType = 5,
                        Number = 3,
                        Name = "Kebab/Gyros sallad",
                        Description = "Kebab/Gyros, Oliver, Salladsost",
                        Price = 80
                    },               
                    new Product() /*--Hamburgare--*/
                    {
                        ProductType = 6,
                        Number = 1,
                        Name = "Happy Burger 45 g",
                        Description = "Ketchup",
                        Price = 40
                    },
                    new Product()
                    {
                        ProductType = 6,
                        Number = 2,
                        Name = "Högrev 200 g",
                        Description = "Högrev Angus, Hickoryrökt Bacon, Amerikansk Dressing, Ketchup, Sallad, Gurka, Tomat",
                        Price = 99
                    },
                    new Product()
                    {
                        ProductType = 6,
                        Number = 3,
                        Name = "SuperBurger 150 g",
                        Description = "Nötkött, Ost, Dressing, Ketchup, Gurka, Tomat",
                        Price = 45
                    },               
                    new Product() /*--Korv--*/
                    {
                        ProductType = 7,
                        Number = 1,
                        Name = "Smal Kokt",
                        Description = "Bröd",
                        Price = 20
                    },
                    new Product()
                    {
                        ProductType = 7,
                        Number = 2,
                        Name = "Smal Grillad",
                        Description = "Strips",
                        Price = 45
                    },
                    new Product()
                    {
                        ProductType = 7,
                        Number = 3,
                        Name = "Smal Grillad Special",
                        Description = "Bröd, Mos",
                        Price = 15
                    },               
                    new Product() /*--A La Carte--*/
                    {
                        ProductType = 8,
                        Number = 1,
                        Name = "Köttbullar med mos",
                        Description = "10 st Köttbullar, lingon, mos",
                        Price = 55
                    },
                    new Product()
                    {
                        ProductType = 8,
                        Number = 2,
                        Name = "Lövbit med Strips",
                        Description = "Lövbit, Strips, Perslijesmör, sallad, gurka, tomat",
                        Price = 55
                    },
                    new Product()
                    {
                        ProductType = 8,
                        Number = 3,
                        Name = "Panerad Flundra",
                        Description = "Kalmarflundra, ströbröd, ägg",
                        Price = 79
                    },               
                    new Product() /*--Kebab--*/
                    {
                        ProductType = 9,
                        Number = 1,
                        Name = "Kebab med bröd",
                        Description = "Kebab, Pitabröd, Sallad, Röd Lök, Gurka, Tomat, Pefferoni, Sås",
                        Price = 65
                    },
                    new Product()
                    {
                        ProductType = 9,
                        Number = 2,
                        Name = "Gyros med bröd",
                        Description = "Gyros, Pitabröd, Sallad, Röd Lök, Gurka, Tomat, Pefferoni, Sås",
                        Price = 65
                    },
                    new Product()
                    {
                        ProductType = 9,
                        Number = 3,
                        Name = "Kycklingrulle",
                        Description = "Kyckling, Tunnbröd, Sallad, Röd Lök, Gurka, Tomat, Pefferoni, Sås",
                        Price = 80
                    },
                    new Product()
                    {
                        ProductType = 9,
                        Number = 4,
                        Name = "Falafeltallrik",
                        Description = "Falafel, Strips, Sallad, Röd Lök, Gurka, Tomat, Pefferoni, Sås",
                        Price = 80
                    },              
                    new Product() /*Tillbehör/Accessories*/
                    {
                        ProductType = 10,
                        Number = 1,
                        Name = "Pizzasallad",
                        Description = "Vitkål, olja, kryddor",
                        Price = 5
                    },
                    new Product()
                    {
                        ProductType = 10,
                        Number = 2,
                        Name = "Rostad Lök",
                        Description = "Gul Lök, kryddor",
                        Price = 5
                    },
                    new Product()
                    {
                        ProductType = 10,
                        Number = 3,
                        Name = "Ananas",
                        Description = "Ananas",
                        Price = 5
                    },              
                    new Product() /*--Såser--*/
                    {
                        ProductType = 11,
                        Number = 1,
                        Name = "Vitlökssås",
                        Description = "Creme Fraiche, vitlök, olivolja",
                        Price = 5
                    },
                    new Product()
                    {
                        ProductType = 11,
                        Number = 2,
                        Name = "Röd stark sås",
                        Description = "Tomatsås, Röd Chili, Grön Chili, Olivolja",
                        Price = 5
                    },
                    new Product()
                    {
                        ProductType = 11,
                        Number = 3,
                        Name = "Road Island",
                        Description = "Road Island",
                        Price = 5
                    },               
                    new Product() /*--Drycker--*/
                    {
                        ProductType = 12,
                        Number = 1,
                        Name = "Coca cola",
                        Description = "33 ml",
                        Price = 15
                    },
                    new Product()
                    {
                        ProductType = 12,
                        Number = 2,
                        Name = "Mineralvatten",
                        Description = "50 ml",
                        Price = 20
                    },
                    new Product()
                    {
                        ProductType = 12,
                        Number = 3,
                        Name = "Fanta",
                        Description = "1 l",
                        Price = 40
                    }
                };

                if (!context.Products.Any())
                { 
                    foreach (Product product in productSeed)
                    {
                        context.Products.Add(product);
                    }
                    context.SaveChanges();          
                }
            }
        }
    }
}
